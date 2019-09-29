package Model;

import java.io.File;
import java.util.Random;

public class Person {
    private String name;
    private boolean male;
    private File file = new File(getClass().getClassLoader().getResource("Resource/Items/noimg.png").getFile());
        
    public File getFile() {
        return file;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public boolean isMale() {
        return male;
    }

    public void setMale(boolean male) {
        this.male = male;
        setPicture(this.male);
    }
    
    public Person() {
        this.name = "";
        this.male = true;
        setPicture(this.male);
    }
    
    public Person(String name, Boolean male) {
        this.name = name;
        this.male = male;
        setPicture(this.male);        
    }
    
    private void setPicture(boolean male)
    {
        Random rnd = new Random();
        int pictureNumber = rnd.nextInt(4) + 1;
        String path = "Resource/Items/";
        if(male)
        {
            path += "m" + Integer.toString(pictureNumber) + ".png";
        }
        else
        {
            path += "f" + Integer.toString(pictureNumber) + ".png";
        }
        
        this.file = new File(getClass().getClassLoader().getResource(path).getFile());
    }   
}
