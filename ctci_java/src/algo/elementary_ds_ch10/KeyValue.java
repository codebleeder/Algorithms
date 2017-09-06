package algo.elementary_ds_ch10;

/**
 * Created by sharads on 9/23/2016.
 */
public class KeyValue {
    public String key;
    public String value;

    public KeyValue(){}

    public KeyValue(String key, String value){
        this.key = key;
        this.value = value;
    }


    public boolean equals(KeyValue b){
        return key == b.key;
    }
}
