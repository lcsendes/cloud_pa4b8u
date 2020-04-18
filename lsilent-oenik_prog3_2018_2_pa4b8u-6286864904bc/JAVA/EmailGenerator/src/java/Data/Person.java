/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Data;

import java.util.*;
import javax.xml.bind.annotation.*;

/**
 *
 * @author LSILENT
 */
@XmlRootElement(name = "person")
public class Person {
    
    @XmlElement(name = "nev")
    String nev;
    
    @XmlElement(name = "allat")
    String allat;
    
    @XmlElement(name = "szam")
    String szerencseszam;
    
    @XmlElement(name = "szin")
    String fogkefeszin;
    
    @XmlElement( name = "email")
    String email;

    public String getNev() {
        return nev;
    }

    public String getAllat() {
        return allat;
    }

    public String getSzerencseszam() {
        return szerencseszam;
    }

    public String getFogkefeszin() {
        return fogkefeszin;
    }

    public String getEmail() {
        return email;
    }

    public Person(String nev, String allat, String szerencseszam, String fogkefeszin) {
        this.nev = nev;
        this.allat = allat;
        this.szerencseszam = szerencseszam;
        this.fogkefeszin = fogkefeszin;
        this.email = RandomEmailGenerator();
    }

    private String RandomEmailGenerator() {
        Random rand = new Random();
        int n = rand.nextInt(4) + 1;
        
        switch (n) {
            case 1:
                return nev + "@gmail.com";
            case 2:
                return fogkefeszin + allat + "@gmail.com";
            case 3:
                return fogkefeszin + szerencseszam + "@gmail.com";
            case 4:
                return fogkefeszin + nev + szerencseszam +"@gmail.com";
            default: return "benavagy@gmail.com";
        }
    }
    
    public Person(){
    }
}
