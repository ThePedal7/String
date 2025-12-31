# UnmanagedString

.The UnmanagedString obj is null terminated
.The Obj itself is a managed class
. It allocates unmanaged heap to a char*
. managed strings are mem copied into char*




// Cleanup

```cs
public class Program {
   public static void Main(string[] args) {
      UnmanagedString str = "Hello, World";

      str.Dispose();
   }
}
```

```cs
public class Program {
   public static void Main(string[] args) {
     using UnmanagedString str = "Hello, World";

      
   }
}
```

```cs
public class Program {
   public static void Main(string[] args) {
      using var scope = new UnmanagedStringScope();

      UnmanagedString str = "Hello, World";
      UnmanagedString str2 = "Hello, World";
      UnmanagedString str3 = "Hello, World";

   
   }
}
```

```cs
public class Program {
   public static void Main(string[] args) {
      using var scope = new UnmanagedStringScope();

      UnmanagedString str = "Hello, World";
      UnmanagedString str2 = "Hello, World";
      UnmanagedString str3 = "Hello, World";
      UnmanagedString[] arr = ["H","Why", "E"];

   
   }
}
```

```cs
public class Program {
   public static void Main(string[] args) {
      

      UnmanagedString str = "Hello, World";
      UnmanagedString str2 = "Hello, World";
      UnmanagedString str3 = "Hello, World";
      UnmanagedString[] arr = ["H","Why", "E"];

      // there is a list that tracks instances 
      // Clean iterates the list and calls Dispose 
      // Clean is what UnmanagedStringScope calls
      UnmanagedString.Clean();
   }

}
```

// Copy Construction

```cs
public class Program {
   public static void Main(string[] args) {
      using var scope = new UnmanagedStringScope();

      UnmanagedString str = "Hello, World";
      UnmanagedString str2 = new(str);
     

   
   }
```

// Move Construction

```cs
public class Program {
   public static void Main(string[] args) {
      using var scope = new UnmanagedStringScope();
      
      UnmanagedString str = "Hello, World";

      // The unmanaged resource is now owned by str2
      UnmanagedString str2 = new( ref str);
      
      Console.WriteLine(str); // output: null 

   
   }
}
```

// Reverse Method

```cs
public class Program {
   public static void Main(string[] args) {
      
       using UnmanagedString str = "Hello, World";
       
       Console.WriteLine(str); // output: Hello, World

       str.Reverse(); // Operation mutates the data

       Console.WriteLine(str); // output: dlroW ,olleH

     
   }
}
```

// SubString Method 


```cs
public class Program {
   public static void Main(string[] args) {
      
       using UnmanagedString str = "Hello, World";

       // takes a start index and returns a new obj
       // with a copy of the data starting from that index
       using UnmanagedString str2 = str.Substring(5);

       // takes a start index and a length
       // returns a new obj with a copy of the data
       // starting at the index and ending when reaching
       // the specified length
       using UnmanagedString str3 = str.SubString(5,2);

       

     
   }
}
```
