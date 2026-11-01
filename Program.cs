IDynArray<int> a = new DynArray<int>();

Console.WriteLine("Add elements:");
Console.WriteLine(a);
    for (int i=0 ; i<20 ; i++) {
        a.Append(i);
        Console.WriteLine(a);
}
        Console.WriteLine("");
        
        Random random = new Random();
        Console.WriteLine("Remove elements:");
        Console.WriteLine(a);
        for (int i=19 ; i>=0 ; i--) {
        a.Remove(random.Next(a.GetFill()));
        Console.WriteLine(a);
}

public class DynArray<T> : IDynArray<T>
{
T[] data;
int capacity;
int fill;

public DynArray () {
    data = new T[0];
    capacity = 0;
    fill = 0;
}
    
public void Append (T element) {
    Expand(1);
    data[fill++] = element;
}

public void Insert (int i, T element) {
    Expand(1);
    for (int j=fill ; j>i ; j++) {
        data[j] = data[j-1];
}
data[i] = element;
fill++;
}

public void Remove (int i) {
    for (i++ ; i<fill ; i++) {
        data[i-1] = data[i];
}
fill--;
Shrink();
}

public void Set (int i, T element) {
    data[i] = element;
}

public T Get (int i) {
    return data[i];
}

public int GetFill () {
    return fill;
}

public override string ToString () {
    string s = "DynArray [";
    for (int i=0 ; i<capacity ; i++) {
        s += (i==0 ? "" : "|")+(i>=fill ? "X" : data[i]);
        }
        s += "] utilization=["+fill+"/"+capacity+"]";
        return s;
}
private void Shrink () {
    if (fill<=capacity/2) {
        capacity = (capacity==1 ? 0 : capacity/2);
            T[] newData = new T[capacity];
                for (int i=0 ; i<fill ; i++) {
                    newData[i] = data[i];
                }
                data = newData;
            }
        }

    private void Expand (int need) {
        while (fill+need>capacity) {
        capacity = (capacity==0 ? 1 : capacity*2);
        T[] newData = new T[capacity];
        for (int i=0 ; i<fill ; i++) {
        newData[i] = data[i];
        }
        data = newData;
        }
    }
}

public interface IDynArray<T>
{
    void Append(T element);
    void Insert(int i, T element);
    void Remove(int i);
    void Set(int i, T element);
    T Get(int i);
    int GetFill();
}