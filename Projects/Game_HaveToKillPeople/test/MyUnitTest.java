import Model.Person;
import Model.Weapon;
import java.io.File;
import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;
import static org.junit.Assert.*;

public class MyUnitTest {
    
    public MyUnitTest() {
    }
    
    @BeforeClass
    public static void setUpClass() {
    }
    
    @AfterClass
    public static void tearDownClass() {
    }
    
    @Before
    public void setUp() {
    }
    
    @After
    public void tearDown() {
    }

    @Test
    public void createPerson()
    {
        String name = "Arnold";
        boolean male = true;
        Person instance = new Person(name, male);
        
        String resultName = instance.getName();
        boolean resultMale = instance.isMale();
        
        String expName = name;
        boolean expMale = true;
        
        assertEquals(expMale, resultMale);
        assertEquals(expName, resultName);
    }
    
    @Test
    public void createPersonRightImageMale()
    {
        String name = "Arnold";
        boolean male = true;
        Person instance = new Person(name, male);
        
        String imgNameFirstLetter = instance.getFile().getName().substring(0,1);
        String expFirstLetter = "m";
        
        assertEquals(expFirstLetter, imgNameFirstLetter);
    }
    
    @Test
    public void createPersonRightImageFemale()
    {
        String name = "Mary";
        boolean male = false;
        Person instance = new Person(name, male);
        
        String imgNameFirstLetter = instance.getFile().getName().substring(0,1);
        String expFirstLetter = "f";
        
        assertEquals(expFirstLetter, imgNameFirstLetter);
    }
    
    @Test
    public void createPersonRightImageNo()
    {
        Person instance = new Person();
        
        String imgNameFirstLetter = instance.getFile().getName().substring(0,1);
        String expFirstLetter = "m";
        
        assertEquals(expFirstLetter, imgNameFirstLetter);
    }
    
    @Test
    public void personSetMaleFalseCheckImage()
    {
        String name = "Arnold";
        boolean male = true;
        Person instance = new Person(name, male);
        instance.setMale(false);
        
        String imgNameFirstLetter = instance.getFile().getName().substring(0,1);
        String expFirstLetter = "f";
        
        assertEquals(expFirstLetter, imgNameFirstLetter);
    }
    
    @Test
    public void personSetMaleTrueCheckImage()
    {
        String name = "Mary";
        boolean male = false;
        Person instance = new Person(name, male);
        instance.setMale(true);
        
        String imgNameFirstLetter = instance.getFile().getName().substring(0,1);
        String expFirstLetter = "m";
        
        assertEquals(expFirstLetter, imgNameFirstLetter);
    }
    
    @Test
    public void weaponClone()
    {
        String name = "Hatchet";
        File f = new File(getClass().getClassLoader().getResource("Resource/w1.png").getFile());
        Weapon expected = new Weapon(name, f);
        Weapon result = (Weapon)expected.Clone();
        
        assertEquals(expected.getName(), result.getName());
        assertEquals(expected.getFile(), result.getFile());
    }

}
