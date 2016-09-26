package algo.elementary_ds_ch10;

/**
 * Created by sharads on 9/23/2016.
 */
public class HashTable {
    public LinkedList2[] hashArray;


    public HashTable(){
        this.hashArray = new LinkedList2[10];
        for (int i=0; i<10; i++){
            this.hashArray[i] = new LinkedList2();
        }

    }

    public HashTable(int size){
        hashArray = new LinkedList2[size];
    }

    private int getIndex(String key){
        int hashCode = Math.abs(key.hashCode());
        int index = hashCode % hashArray.length;
        return  index; // hash function
    }

    public void insert(String key, String value){
        KeyValue keyValue = new KeyValue(key, value);
        int index = getIndex(key);
        hashArray[index].insert(new ListObject2(keyValue));
    }

    public String search(String key){
        int index = getIndex(key);
        ListObject2 listObject = hashArray[index].search(key);
        return listObject.key.value;
    }

}
