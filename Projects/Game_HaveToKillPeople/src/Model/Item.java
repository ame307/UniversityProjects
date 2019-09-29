package Model;

import java.io.File;


public abstract class Item{

    private String name;

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    private File file = null;
    
    public File getFile() {
        return file;
    }

    public void setFile(File file) {
        this.file = file;
    }
    
    public abstract Object Clone();
    
    public Item() {

    }
    
    public Item(String name, File file) {
        this.name = name;
        this.file = file;
    }
    
        
}
