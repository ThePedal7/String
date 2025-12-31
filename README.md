# UnmanagedString
//Cleanup

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
// Copy Construction
```cs
public class Program {
   public static void Main(string[] args) {
      using var scope = new UnmanagedStringScope();
      UnmanagedString str = "Hello, World";
      UnmanagedString str2 = new(str);
     

   
   }
}
```
