public class Node {
    public object value;
    public object next;

    public Node()
    {
        this.value = null;
        this.next = null;
    }

    public Node(object value)
    {
        this.value = value;
        this.next = null;
    }

    public Node(object value, object next)
    {
        this.value = value;
        this.next = next;
    }
}