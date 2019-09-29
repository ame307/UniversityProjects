package View;

import Common.Logging;
import Model.Weapon;
import Common.Rotation;
import java.awt.Dimension;
import java.awt.Graphics2D;
import java.awt.GraphicsConfiguration;
import java.awt.GraphicsDevice;
import java.awt.GraphicsEnvironment;
import java.awt.Image;
import java.awt.Toolkit;
import java.awt.event.ActionListener;
import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
import java.util.Random;
import javax.imageio.ImageIO;
import javax.swing.*;

public class GameView extends javax.swing.JFrame {

    public GameView() {
        initComponents();
        myinitComponents();
    }
    
    private Weapon prototype = new Weapon();
    private List<JLabel> people = new ArrayList<JLabel>();
    private List<JLabel> people2 = new ArrayList<JLabel>();
    private List<JLabel> weapons = new ArrayList<JLabel>();
    private boolean gameDone = false;

    public void setGameDone(boolean gameDone) {
        this.gameDone = gameDone;
    }

    public boolean isGameDone() {
        return gameDone;
    }
      
    public List<JLabel> getPeople()
    {
        return this.people;
    }
    
    public void setPeople(List<JLabel> people)
    {
        this.people = people;
    }
    
    public List<JLabel> getPeople2()
    {
        return this.people2;
    }
    
    public void setPeople2(List<JLabel> people2)
    {
        this.people2 = people2;
    }
    
    public List<JLabel> getPeopleWithWeapon()
    {
        List<JLabel> list = new ArrayList<>();
        for (int i = 0; i < weapons.size(); i++) {
            list.add(people2.get(i));
        }
        return list;
    }
        
    public List<JLabel> getWeapons()
    {
        return this.weapons;
    }
    
    public void setWeapons(List<JLabel> weapons)
    {
        this.weapons = weapons;
    }
    
    public void setProtoype(Weapon weapon)
    {
        this.prototype = weapon;
    }
    
    public Weapon getProtoype()
    {
        return this.prototype;
    }
    
    public void addWeapon1ActionListener(ActionListener listener)
    {
        this.btnWeapon1.addActionListener(listener);
    }
    
    public void addWeapon2ActionListener(ActionListener listener)
    {
        this.btnWeapon2.addActionListener(listener);
    }
    
    public void addWeapon3ActionListener(ActionListener listener)
    {
        this.btnWeapon3.addActionListener(listener);
    }
    
    public void addWeapon4ActionListener(ActionListener listener)
    {
        this.btnWeapon4.addActionListener(listener);
    }
    
    public void addMenu0ActionListener(ActionListener listener)
    {
        this.btnMenu0.addActionListener(listener);
    }
    
    public void addMenu1ActionListener(ActionListener listener)
    {
        this.btnMenu1.addActionListener(listener);
    }
    
    public void addMenu2ActionListener(ActionListener listener)
    {
        this.btnMenu2.addActionListener(listener);
    }
    
    public void addMenu3ActionListener(ActionListener listener)
    {
        this.btnMenu3.addActionListener(listener);
    }
         
    public JLabel getMessageLabel()
    {
        return messageLabel;
    }

    public JButton getBtnMenu0() {
        return btnMenu1;
    }
    
    public JButton getBtnMenu1() {
        return btnMenu1;
    }
    
    public JButton getBtnMenu2() {
        return btnMenu2;
    }
    
    public JButton getBtnMenu3() {
        return btnMenu3;
    }
    
    public JToggleButton getBtnWeapon1() {
        return btnWeapon1;
    }
    
    public JToggleButton getBtnWeapon2() {
        return btnWeapon2;
    }
    
    public JToggleButton getBtnWeapon3() {
        return btnWeapon3;
    }
    
    public JToggleButton getBtnWeapon4() {
        return btnWeapon4;
    }
    
    public JPanel getPanel() {
        return panel;
    }
   
    /**
     * Create a label with the given image, on the JPanel.
     * @param image 
     */
    public void drawImage(BufferedImage image)
    {
        JLabel label = new JLabel(new ImageIcon(image));
        Random rnd = new Random();
        int x = rnd.nextInt(panel.getWidth()-50);
        int y = rnd.nextInt(panel.getHeight()/2-130);
        label.setLocation(x, y);
        label.setSize(50, 130);
        people.add(label);
        this.panel.add(label);
        this.panel.validate();
        this.panel.repaint();
        Logging.log("Kirajzolva.");
    }
    
    /**
     * Create a label with the given image at given position on the JPanel.
     * @param image
     * @param x
     * @param y 
     */
    public void drawImagePos(BufferedImage image, int x, int y)
    {
        if(image != null)
        {
            JLabel label = new JLabel(new ImageIcon(image));
            label.setLocation(x, y);
            label.setSize(50, 130);
            people2.add(people.get(0));
            people.remove(0);
            weapons.add(label);  
            this.panel.add(label);
            this.panel.validate();
            this.panel.repaint();
            Logging.log("Kirajzolva.");
        }
        
    }
    
    /**
     * I do not know how it works, and what it does.
     * @param label
     * @param angle 
     */
    
    public void rotateLabel(JLabel label, double angle)
    {
        Image img = iconToImage(label.getIcon());
        BufferedImage image = toBufferedImage(img);
        image = Rotation.rotateImage(image, angle);
        label.setSize(image.getWidth(), image.getHeight());
        label.setIcon(new ImageIcon(image));
    }
    
    private Image iconToImage(Icon icon) {
           if (icon instanceof ImageIcon) {
               return ((ImageIcon)icon).getImage();
           } else {
                int w = icon.getIconWidth();
                int h = icon.getIconHeight();
                GraphicsEnvironment ge =
                GraphicsEnvironment.getLocalGraphicsEnvironment();
                GraphicsDevice gd = ge.getDefaultScreenDevice();
                GraphicsConfiguration gc = gd.getDefaultConfiguration();
                BufferedImage image = gc.createCompatibleImage(w, h);
                Graphics2D g = image.createGraphics();
                icon.paintIcon(null, g, 0, 0);
                g.dispose();
                return image;
        }
    }
    
    private BufferedImage toBufferedImage(Image img)
    {
        if (img instanceof BufferedImage)
        {
            return (BufferedImage) img;
        }

        // Create a buffered image with transparency
        BufferedImage bimage = new BufferedImage(img.getWidth(null), img.getHeight(null), BufferedImage.TYPE_INT_ARGB);

        // Draw the image on to the buffered image
        Graphics2D bGr = bimage.createGraphics();
        bGr.drawImage(img, 0, 0, null);
        bGr.dispose();

        // Return the buffered image
        return bimage;
    }
    
    /**
     * Removes all of the weapons from the Panel.
     */
    public void removeWeapons()
    {
        for(int i = 0; i<weapons.size(); i++)
        {
            panel.remove(weapons.get(i));
        }
        
        panel.revalidate();
        panel.repaint();
    }
    
    /**
     * Reset the game.
     */
    public void Reset() {
        btnWeapon1.setSelected(false);
        btnWeapon2.setSelected(false);
        btnWeapon3.setSelected(false);
        btnWeapon4.setSelected(false);
        prototype = new Weapon();
        people = new ArrayList<JLabel>();
        people2 = new ArrayList<JLabel>();
        weapons = new ArrayList<JLabel>();
        if(gameDone)
        {
            messageLabel.setIcon(new javax.swing.ImageIcon(getClass().getResource("/Resource/UI/message4.png")));
        }
        gameDone = false;
        panel.removeAll();
        panel.validate();
        panel.repaint();
    }
      
    /**
     * This method is called from within the constructor to initialize the form.
     * WARNING: Do NOT modify this code. The content of this method is always
     * regenerated by the Form Editor.
     */
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        btnWeapon1 = new javax.swing.JToggleButton();
        btnWeapon2 = new javax.swing.JToggleButton();
        btnWeapon3 = new javax.swing.JToggleButton();
        btnWeapon4 = new javax.swing.JToggleButton();
        btnMenu3 = new javax.swing.JButton();
        btnMenu1 = new javax.swing.JButton();
        btnMenu2 = new javax.swing.JButton();
        panel = new javax.swing.JPanel();
        btnMenu0 = new javax.swing.JButton();
        messageLabel = new javax.swing.JLabel();

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);
        setTitle("Have To Kill People");
        setBackground(java.awt.Color.black);
        setMinimumSize(new java.awt.Dimension(1440, 720));
        setName("frame"); // NOI18N
        setPreferredSize(new java.awt.Dimension(1440, 720));
        setResizable(false);
        setSize(new java.awt.Dimension(1440, 720));

        btnMenu3.setMaximumSize(new java.awt.Dimension(145, 25));
        btnMenu3.setMinimumSize(new java.awt.Dimension(145, 25));
        btnMenu3.setPreferredSize(new java.awt.Dimension(145, 25));

        btnMenu1.setMaximumSize(new java.awt.Dimension(145, 35));
        btnMenu1.setMinimumSize(new java.awt.Dimension(145, 35));
        btnMenu1.setPreferredSize(new java.awt.Dimension(145, 35));

        btnMenu2.setToolTipText("");
        btnMenu2.setMaximumSize(new java.awt.Dimension(145, 25));
        btnMenu2.setMinimumSize(new java.awt.Dimension(145, 25));
        btnMenu2.setPreferredSize(new java.awt.Dimension(145, 25));

        panel.setBackground(new java.awt.Color(255, 255, 255));

        javax.swing.GroupLayout panelLayout = new javax.swing.GroupLayout(panel);
        panel.setLayout(panelLayout);
        panelLayout.setHorizontalGroup(
            panelLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGap(0, 1416, Short.MAX_VALUE)
        );
        panelLayout.setVerticalGroup(
            panelLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGap(0, 583, Short.MAX_VALUE)
        );

        btnMenu0.setMaximumSize(new java.awt.Dimension(145, 25));
        btnMenu0.setMinimumSize(new java.awt.Dimension(145, 25));
        btnMenu0.setPreferredSize(new java.awt.Dimension(145, 25));

        messageLabel.setBackground(new java.awt.Color(0, 0, 0));

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(layout.createSequentialGroup()
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addComponent(panel, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                            .addGroup(layout.createSequentialGroup()
                                .addComponent(btnWeapon1, javax.swing.GroupLayout.PREFERRED_SIZE, 340, javax.swing.GroupLayout.PREFERRED_SIZE)
                                .addGap(18, 18, 18)
                                .addComponent(btnWeapon2, javax.swing.GroupLayout.PREFERRED_SIZE, 340, javax.swing.GroupLayout.PREFERRED_SIZE)
                                .addGap(18, 18, 18)
                                .addComponent(btnWeapon3, javax.swing.GroupLayout.PREFERRED_SIZE, 340, javax.swing.GroupLayout.PREFERRED_SIZE)
                                .addGap(18, 18, 18)
                                .addComponent(btnWeapon4, javax.swing.GroupLayout.PREFERRED_SIZE, 340, javax.swing.GroupLayout.PREFERRED_SIZE)))
                        .addGap(0, 0, Short.MAX_VALUE))
                    .addGroup(layout.createSequentialGroup()
                        .addComponent(btnMenu0, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addComponent(messageLabel, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                        .addGap(235, 235, 235)
                        .addComponent(btnMenu1, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                        .addComponent(btnMenu2, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                        .addComponent(btnMenu3, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)))
                .addContainerGap())
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addComponent(btnMenu0, javax.swing.GroupLayout.Alignment.TRAILING, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                    .addComponent(messageLabel, javax.swing.GroupLayout.Alignment.TRAILING, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                    .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                        .addGap(0, 0, Short.MAX_VALUE)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                            .addComponent(btnMenu1, javax.swing.GroupLayout.PREFERRED_SIZE, 40, javax.swing.GroupLayout.PREFERRED_SIZE)
                            .addComponent(btnMenu2, javax.swing.GroupLayout.PREFERRED_SIZE, 40, javax.swing.GroupLayout.PREFERRED_SIZE)
                            .addComponent(btnMenu3, javax.swing.GroupLayout.PREFERRED_SIZE, 40, javax.swing.GroupLayout.PREFERRED_SIZE))))
                .addGap(18, 18, 18)
                .addComponent(panel, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addComponent(btnWeapon1, javax.swing.GroupLayout.PREFERRED_SIZE, 50, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                        .addComponent(btnWeapon2, javax.swing.GroupLayout.PREFERRED_SIZE, 50, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addComponent(btnWeapon3, javax.swing.GroupLayout.PREFERRED_SIZE, 50, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addComponent(btnWeapon4, javax.swing.GroupLayout.PREFERRED_SIZE, 50, javax.swing.GroupLayout.PREFERRED_SIZE)))
                .addContainerGap())
        );

        pack();
    }// </editor-fold>//GEN-END:initComponents
    
    private void myinitComponents() {
        
        this.setIconImage(new ImageIcon(getClass().getClassLoader().getResource("Resource/UI/icon.png")).getImage());
        this.setSize(1440, 720);
        Dimension dim = Toolkit.getDefaultToolkit().getScreenSize();
        this.setLocation(dim.width/2-this.getSize().width/2, dim.height/2-this.getSize().height/2);
        this.setVisible(true);
        
        btnMenu0.setIcon(new javax.swing.ImageIcon(getClass().getResource("/Resource/UI/reset.png")));
        btnMenu1.setIcon(new javax.swing.ImageIcon(getClass().getResource("/Resource/UI/kill.png")));
        btnMenu2.setIcon(new javax.swing.ImageIcon(getClass().getResource("/Resource/UI/weapon.png")));
        btnMenu3.setIcon(new javax.swing.ImageIcon(getClass().getResource("/Resource/UI/person.png")));
        messageLabel.setIcon(new javax.swing.ImageIcon(getClass().getResource("/Resource/UI/message1.png")));
        
        
        btnMenu0.setFocusPainted(false);
        btnMenu1.setFocusPainted(false);
        btnMenu2.setFocusPainted(false);
        btnMenu3.setFocusPainted(false);
        btnWeapon1.setFocusPainted(false);
        btnWeapon2.setFocusPainted(false);
        btnWeapon3.setFocusPainted(false);
        btnWeapon4.setFocusPainted(false);

        messageLabel.setBackground(java.awt.Color.BLACK);
        btnMenu0.setBackground(java.awt.Color.BLACK);
        btnMenu1.setBackground(java.awt.Color.BLACK);
        btnMenu2.setBackground(java.awt.Color.BLACK);
        btnMenu3.setBackground(java.awt.Color.BLACK);
        btnWeapon1.setBackground(java.awt.Color.BLACK);
        btnWeapon2.setBackground(java.awt.Color.BLACK);
        btnWeapon3.setBackground(java.awt.Color.BLACK);
        btnWeapon4.setBackground(java.awt.Color.BLACK);
        
        btnMenu0.setBorderPainted(false);
        btnMenu1.setBorderPainted(false);
        btnMenu2.setBorderPainted(false);
        btnMenu3.setBorderPainted(false);
        btnWeapon1.setBorderPainted(false);
        btnWeapon2.setBorderPainted(false);
        btnWeapon3.setBorderPainted(false);
        btnWeapon4.setBorderPainted(false);
        
        Weapon w1 = new Weapon("Hatchet", new File(getClass().getClassLoader().getResource("Resource/Items/w1.png").getFile()));
        Weapon w2= new Weapon("Axe", new File(getClass().getClassLoader().getResource("Resource/Items/w2.png").getFile()));
        Weapon w3 = new Weapon("Mace", new File(getClass().getClassLoader().getResource("Resource/Items/w3.png").getFile()));
        Weapon w4 = new Weapon("Sword", new File(getClass().getClassLoader().getResource("Resource/Items/w4.png").getFile()));
        
        setIcon(w1.getFile(), btnWeapon1);
        setIcon(w2.getFile(), btnWeapon2);
        setIcon(w3.getFile(), btnWeapon3);
        setIcon(w4.getFile(), btnWeapon4);        
    }
    
    private void setIcon(File file, JToggleButton button)
    {
        BufferedImage original = null;
            try {
                original = ImageIO.read(file); 
            } catch (IOException ex) {
                ex.printStackTrace();
            }
        button.setIcon(new ImageIcon(Rotation.rotateImage(original, 90.0)));
    }
    
    /**
     * @param args the command line arguments
     */
    public static void main(String args[]) {
        /* Set the Nimbus look and feel */
        //<editor-fold defaultstate="collapsed" desc=" Look and feel setting code (optional) ">
        /* If Nimbus (introduced in Java SE 6) is not available, stay with the default look and feel.
         * For details see http://download.oracle.com/javase/tutorial/uiswing/lookandfeel/plaf.html 
         */
        try {
            for (javax.swing.UIManager.LookAndFeelInfo info : javax.swing.UIManager.getInstalledLookAndFeels()) {
                if ("Nimbus".equals(info.getName())) {
                    javax.swing.UIManager.setLookAndFeel(info.getClassName());
                    break;
                }
            }
        } catch (ClassNotFoundException ex) {
            java.util.logging.Logger.getLogger(GameView.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (InstantiationException ex) {
            java.util.logging.Logger.getLogger(GameView.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (IllegalAccessException ex) {
            java.util.logging.Logger.getLogger(GameView.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (javax.swing.UnsupportedLookAndFeelException ex) {
            java.util.logging.Logger.getLogger(GameView.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        }
        //</editor-fold>

        /* Create and display the form */
        java.awt.EventQueue.invokeLater(new Runnable() {
            public void run() {
                new GameView().setVisible(true);
            }
        });
    }

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton btnMenu0;
    private javax.swing.JButton btnMenu1;
    private javax.swing.JButton btnMenu2;
    private javax.swing.JButton btnMenu3;
    private javax.swing.JToggleButton btnWeapon1;
    private javax.swing.JToggleButton btnWeapon2;
    private javax.swing.JToggleButton btnWeapon3;
    private javax.swing.JToggleButton btnWeapon4;
    private javax.swing.JLabel messageLabel;
    private javax.swing.JPanel panel;
    // End of variables declaration//GEN-END:variables
}
