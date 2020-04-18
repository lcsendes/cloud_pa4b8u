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
@XmlRootElement(name = "people")
public class People {
    
    List<Person> personlist;

    public People(String nev, String allat, String szerencseszam, String szin) {
        personlist = new ArrayList();
        personlist.add(new Person(nev, allat, szerencseszam, szin));
        personlist.add(new Person(nev, allat, szerencseszam, szin));
        personlist.add(new Person(nev, allat, szerencseszam, szin));
        personlist.add(new Person(nev, allat, szerencseszam, szin));
    }
    
    @XmlElement(name = "person")
    public List<Person> getPersonlist() {
        return personlist;
    }
    
    public People(){
        
    }
    
}
