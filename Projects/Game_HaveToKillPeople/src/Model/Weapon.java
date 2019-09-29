package Model;

import java.io.File;

public class Weapon extends Item{

    @Override
    public Object Clone() {
        Weapon temp = new Weapon(this.getName(), this.getFile());
        return temp;
    }

    public Weapon() {

    }
    
    public Weapon(String name, File file) {
        super(name, file);
    }
    
}
