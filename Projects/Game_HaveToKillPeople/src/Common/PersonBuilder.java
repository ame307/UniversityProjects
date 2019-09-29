package Common;

import Model.Person;
import Common.Logging;

public class PersonBuilder {
    
    private Person person;
    
    public PersonBuilder setName(String name)
    {
        this.person.setName(name);
        Logging.log("Ember nevének beállítása: " + name);
        return this;
    }
    
    public PersonBuilder setGender(Boolean male)
    {
        this.person.setMale(male);
        Logging.log("Ember nemének beállítása.");
        return this;
    }
    
    public Person Build()
    {
        Logging.log("Ember elkészítve.");
        return person;
    }
    
    public PersonBuilder()
    {
        this.person = new Person();
    }
    
}
