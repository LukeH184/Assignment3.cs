using System;
using System.Collections.Generic;

class Program {
  public static void Main (string[] args) {
    string name;
    int choice;
    double WS;
    double WST;
    List<Faculty> list = new List<Faculty>(); 
    while (true){
      Console.WriteLine();
      Console.WriteLine("Menu: ");
      Console.WriteLine("1 - Add Faculty");
      Console.WriteLine("2 - Delete Faculty");
      Console.WriteLine("3 - Calculate Faculty Pay");
      Console.WriteLine("4 - Print Faculty");
      Console.WriteLine("5 - Exit");
      choice = Convert.ToInt32(Console.ReadLine());
      Console.WriteLine();
      switch (choice){
        case 1:
        addFaculty(list);
        break;
        case 2:
        removeFaculty(list);
        break;
        case 3:
        calculateFacultyPay(list);
        break;
        case 4:
        printFaculty(list);
        break;
        case 5:
        System.Environment.Exit(0);
        break;
        default:
        Console.WriteLine("Please enter a valid input.");
        break;
      }
    }
  
    void addFaculty(List<Faculty> f){
    Console.Write("Enter a name:");
    name = Console.ReadLine();
    Console.Write("Enter a weekly salary:");
    WS = Convert.ToDouble(Console.ReadLine());
    Console.Write("Enter a weekly stipend:");
    WST = Convert.ToDouble(Console.ReadLine());
    list.Add(new Faculty(name, WS, WST));
    }
   
   void removeFaculty(List<Faculty> f){
      Console.Write("Enter a employee to remove:");
      name = Console.ReadLine();
      string NAME;
      bool found = false;
      for (int i = 0; i < f.Count; i++){
        Faculty index = f[i];
        NAME = Convert.ToString(index.getName());
        if(NAME == name){
          found = true;
          f.RemoveAt(i);
          Faculty.decreaseNumberOfEmployees();
        }
      }
      if(!found){
        Console.WriteLine("Employee not found");
      }
    }
    void calculateFacultyPay(List<Faculty> f){
      Faculty index;
      for (int i = 0; i < f.Count; i++){
        index = f[i];
        index.calculateWeekly_Pay();
      }
    }
    void printFaculty(List<Faculty> f){
      Faculty index;
      for (int i = 0; i < f.Count; i++){
        index = f[i];
        Console.WriteLine(index);
      }
    }
  }
  abstract class Employee{
    private string name;
    private int Employee_ID;
    static private int num_of_Employee = 0;
    public Employee(){
      this.name = "new employee";
      this.Employee_ID = num_of_Employee++;
    }
    public Employee(string n){
      this.name = n;
      this.Employee_ID = num_of_Employee++;
    }
    public string getName(){
      return name;
    }
    public void setName(string n){
      name = n;
    }
    public int getID(){
      return Employee_ID;
    }
    public void setID(int x){
      Employee_ID = x;
    }
    public static int getNumberOfEmployees(){
      return num_of_Employee;
    }
    public static void decreaseNumberOfEmployees(){
      num_of_Employee--;
    }
  }
  class Faculty : Employee{
    private double salary_week;
    private double stipend_week;
    private double pay_week;
    public Faculty(string n, double sal, double stip) {
      base.setName(n);
      salary_week = sal;
      stipend_week = stip;
    }
    public void setSalary_week(double s){
      salary_week = s;
    }
    public double getSalary_week(){
      return salary_week;
    }
    public void setStipend_week(double s){
      stipend_week = s;
    }
    public double getStipend_week(){
      return stipend_week;
    }
    public void calculateWeekly_Pay(){
      pay_week = salary_week + stipend_week;
    }
    public double getPay_week(){
      return pay_week;
    }
    public override string ToString(){
      return ("Employee name: " + base.getName() +  ", Weekly salary: "+ getSalary_week() + ", Weekly stipend: " + getStipend_week() + " Weekly pay: " + getPay_week());
    }
  }
}