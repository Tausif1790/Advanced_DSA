//Consider the following class Student

public class Student {
   int age;
   String name;

   void display(){
       System.out.println("My name is " + this.name + ". I am "  + this.age + " years old");
   }

   void sayHello(String name){
       System.out.println(this.name + " says hello to " + name);
   }
}

public class Client {
   public static void main(String[] args) {
       Student s1 = new Student();
       s1.age = 10;
       s1.name = "A";
       s1.display();

       Student s2 = s1;  // now s2 refer s1 (address), when we change s2 value s1 value will also be changed
       s2.age = 20;
       s2.name = "B";

       s2.display();

       s1.display();
   }
}
//What is the output of the final call to display function i.e. s1.display()?
/*
My name is B. I am 20 years old.
This is because the s2 object is assigned a reference to the same object as s1,
 so both variables refer to the same object in memory. 
 Therefore, when we modify the values of s2, we are actually modifying the values of the same object 
 that s1 refers to. So when we call s1.display after modifying s2,
  it will reflect the updated values of s2, which are "B" and 20.
  */