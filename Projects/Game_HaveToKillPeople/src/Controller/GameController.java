package Controller;

import Common.Logging;
import Common.PersonBuilder;
import Model.Person;
import Model.Weapon;
import View.GameView;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.image.BufferedImage;
import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
import java.util.Random;
import java.util.concurrent.ScheduledExecutorService;
import java.util.concurrent.ScheduledFuture;
import java.util.concurrent.ScheduledThreadPoolExecutor;
import java.util.concurrent.TimeUnit;
import javax.imageio.ImageIO;
import javax.swing.JLabel;
import javax.swing.JToggleButton;

public class GameController {
    
    private GameView view;
    private List<String> maleNames = readNames("Resource/Files/male_names.txt");
    private List<String> femaleNames = readNames("Resource/Files/female_names.txt");
    
    public GameController(GameView view)
    {
        this.view = view;
        
        view.addWeapon1ActionListener(new Weapon1Listener());
        view.addWeapon2ActionListener(new Weapon2Listener());
        view.addWeapon3ActionListener(new Weapon3Listener());
        view.addWeapon4ActionListener(new Weapon4Listener());
        view.addMenu0ActionListener(new Menu0Listener());
        view.addMenu1ActionListener(new Menu1Listener());
        view.addMenu2ActionListener(new Menu2Listener());
        view.addMenu3ActionListener(new Menu3Listener());         
    }
    
    private List<String> readNames(String path)
    {
        List<String> list = new ArrayList<>();
        
        try {

            File f = new File(getClass().getClassLoader().getResource(path).getFile());

            BufferedReader b = new BufferedReader(new FileReader(f));

            String readLine = "";

            while ((readLine = b.readLine()) != null) {
                list.add(readLine);
            }

        } catch (IOException e) {
            e.printStackTrace();
        }
        
        return list;
    }
    
    class Menu0Listener implements ActionListener {

        @Override
        public void actionPerformed(ActionEvent e) {
            
            view.Reset();
            Logging.log("Reset");

        }
        
    }
    
    class Menu1Listener implements ActionListener {

        double angle = 0;
        
        @Override
        public void actionPerformed(ActionEvent e) {
            
            if(!view.isGameDone() && view.getWeapons().size() == view.getPeople2().size() + view.getPeople().size() && 
                view.getPeople2().size() + view.getPeople().size() > 0)
            {
                view.setGameDone(true);
                view.getMessageLabel().setIcon(new javax.swing.ImageIcon(getClass().getResource("/Resource/UI/message3.png")));
                List<JLabel> weapons = view.getWeapons();
                int delay = 3;
                int interval = 300 * delay; 
                Logging.log("Emberek megölése");
                moveAnimation(weapons, delay, interval);
                new java.util.Timer().schedule( 
                        new java.util.TimerTask() {
                            @Override
                            public void run() {
                                view.removeWeapons();
                                int delay = 10;
                                int interval = 90 * delay;
                                List<JLabel> people = view.getPeopleWithWeapon();
                                rotateAnimation(people, delay, interval);
                            }
                        }, 
                        delay * 300
                );
            }
            else if(view.getPeople2().size() + view.getPeople().size() > 0)
            {
                view.getMessageLabel().setIcon(new javax.swing.ImageIcon(getClass().getResource("/Resource/UI/message2.png")));
            }
        }
            
        private void moveAnimation(List<JLabel> labels,int delay, int interval)
        {
            ScheduledExecutorService executor = new ScheduledThreadPoolExecutor(2);
            ScheduledFuture<?> schedule = executor.scheduleAtFixedRate(() -> {
                for (int i = 0; i < labels.size(); i++) {
                    labels.get(i).setLocation(labels.get(i).getLocation().x,labels.get(i).getLocation().y - 1);
                }
            }, 0, delay, TimeUnit.MILLISECONDS);

            executor.schedule(() -> schedule.cancel(false), interval, TimeUnit.MILLISECONDS);
        }
        
        
        //BufferedImage image = new BufferedImage(ico.getIconHeight(), ico.getIconHeight(), BufferedImage.TYPE_INT_ARGB);
        //labels.get(i).setIcon(new ImageIcon(Rotation.rotateImage(image, 1.0)));    
        
        private void rotateAnimation(List<JLabel> labels,int delay, int interval)
        {
            ScheduledExecutorService executor = new ScheduledThreadPoolExecutor(2);
            ScheduledFuture<?> schedule = executor.scheduleAtFixedRate(() -> {
                for (int i = 0; i < labels.size(); i++) {
                        view.rotateLabel(labels.get(i), 1);                              
                }
            }, 0, delay, TimeUnit.MILLISECONDS);

            executor.schedule(() -> schedule.cancel(false), interval, TimeUnit.MILLISECONDS);
        }
    }
    
    

    class Menu2Listener implements ActionListener {

        @Override
        public void actionPerformed(ActionEvent e) {
            
            if(!view.isGameDone())
            {
                Logging.log("Fegyver kirajzolási kísérlet.");
                List<JLabel> people = view.getPeople();
                if(!people.isEmpty())
                {
                    int x = people.get(0).getLocation().x;
                    int y = people.get(0).getLocation().y + 300;

                    BufferedImage image = null;
                    try {
                        image = ImageIO.read(view.getProtoype().getFile()); 
                    } catch (Exception ex) {

                    }

                    view.drawImagePos(image, x, y);
                }
            }
        }
    }

    class Menu3Listener implements ActionListener {

        @Override
        public void actionPerformed(ActionEvent e) {
            if(!view.isGameDone())
            {
                Logging.log("Ember megépítésének elkezdése.");
                PersonBuilder pb = new PersonBuilder();
                Random rnd = new Random();
                boolean male = rnd.nextBoolean();
                Person person;
                if(male)
                {
                    person = pb.setGender(male).setName(anyName(maleNames)).Build();
                }
                else
                {
                    person = pb.setGender(male).setName(anyName(femaleNames)).Build();
                }

                BufferedImage image = null;
                try {
                    image = ImageIO.read(person.getFile()); 
                } catch (IOException ex) {
                    ex.printStackTrace();
                }

                Logging.log("Ember kirajzolási kísérlet.");
                view.drawImage(image);
            }
        }
        
        private String anyName(List<String> list)
        {
            Random rnd = new Random();
            int index = rnd.nextInt(list.size());
            String randomString = list.get(index);
            return randomString;
        }
    }
    

    class Weapon1Listener implements ActionListener {

        @Override
        public void actionPerformed(ActionEvent e) {
            
            view.getBtnWeapon2().setSelected(false);
            view.getBtnWeapon3().setSelected(false);
            view.getBtnWeapon4().setSelected(false);
            if(((JToggleButton) e.getSource()).isSelected()) 
            {
                Weapon wep = new Weapon("Hatchet", new File(getClass().getClassLoader().getResource("Resource/Items/w1.png").getFile()));
                view.setProtoype(wep);
                Logging.log(wep.getName() + " fegyver kiválasztva.");
            }
            else
            {
                view.setProtoype(null);
                Logging.log("Kiválasztás megszüntetétse.");
            }
        }
    }

    class Weapon2Listener implements ActionListener {

        @Override
        public void actionPerformed(ActionEvent e) {
            view.getBtnWeapon1().setSelected(false);
            view.getBtnWeapon3().setSelected(false);
            view.getBtnWeapon4().setSelected(false);
            if(((JToggleButton) e.getSource()).isSelected()) {
                Weapon wep = new Weapon("Axe", new File(getClass().getClassLoader().getResource("Resource/Items/w2.png").getFile()));
                view.setProtoype(wep);
                Logging.log(wep.getName() + " fegyver kiválasztva.");
            }
            else
            {
                view.setProtoype(null);
                Logging.log("Kiválasztás megszüntetétse.");
            }
        }
    }

    class Weapon3Listener implements ActionListener {

        @Override
        public void actionPerformed(ActionEvent e) {
            view.getBtnWeapon1().setSelected(false);
            view.getBtnWeapon2().setSelected(false);
            view.getBtnWeapon4().setSelected(false);
            if(((JToggleButton) e.getSource()).isSelected()) {
                Weapon wep = new Weapon("Mace", new File(getClass().getClassLoader().getResource("Resource/Items/w3.png").getFile()));
                view.setProtoype(wep);
                Logging.log(wep.getName() + " fegyver kiválasztva.");
            }
            else
            {
                view.setProtoype(null);
                Logging.log("Kiválasztás megszüntetétse.");
            }
        }
    }

    class Weapon4Listener implements ActionListener {

        @Override
        public void actionPerformed(ActionEvent e) {
            view.getBtnWeapon1().setSelected(false);
            view.getBtnWeapon2().setSelected(false);
            view.getBtnWeapon3().setSelected(false);
            if(((JToggleButton) e.getSource()).isSelected()) {
                Weapon wep = new Weapon("Sword", new File(getClass().getClassLoader().getResource("Resource/Items/w4.png").getFile()));
                view.setProtoype(wep);
                Logging.log(wep.getName() + " fegyver kiválasztva.");
            }
            else
            {
                view.setProtoype(null);
                Logging.log("Kiválasztás megszüntetétse.");
            }
        }
    } 
}

