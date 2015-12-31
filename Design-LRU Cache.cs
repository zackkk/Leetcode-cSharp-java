Design and implement a data structure for Least Recently Used (LRU) cache. 
It should support the following operations: get and set.

get(key) - Get the value (will always be positive) of the key if the key exists in the cache, otherwise return -1.
set(key, value) - Set or insert the value if the key is not already present. When the cache reached its capacity, 
it should invalidate the least recently used item before inserting a new item.


public class LRUCache {
    // idea: hashma<key, Node> + doubly linked list + head-tail
    
    public class Node {
        public Node prev;
        public Node next;
        public int key, val;
        public Node(int k, int x) { key = k; val = x; }
    }

    Dictionary<int, Node> dict;
    Node head, tail;
    int capacity;

    public LRUCache(int capacity) {
        this.capacity = capacity;
        dict = new Dictionary<int, Node>();
        head = new Node(0, 0);
        tail = new Node(0, 0);
        head.next = tail;
        tail.prev = head;
    }
    
    void MoveNodeToHead(Node node){
        node.prev = head;
        node.next = head.next;
        
        head.next.prev = node;
        head.next = node;
    }
    
    // remove from doubly linked list
    void RemoveNode(Node node){
        Node prevNode = node.prev;
        Node nextNode = node.next;
        
        prevNode.next = nextNode;
        nextNode.prev = prevNode;
    }

    // update position in doubly linked list
    public int Get(int key) {
        if(dict.ContainsKey(key)) {
            RemoveNode(dict[key]);
            MoveNodeToHead(dict[key]);
            return dict[key].val;
        }
        return -1;
    }

    public void Set(int key, int value) {
        if(dict.ContainsKey(key)){
            dict[key].val = value;
            RemoveNode(dict[key]);
            MoveNodeToHead(dict[key]);
        }
        else{
            Node node = new Node(key, value);
            dict[key] = node;
            MoveNodeToHead(node);
            if(dict.Count > capacity) {
                dict.Remove(tail.prev.key);
                RemoveNode(tail.prev);
            }
        }
    }
}