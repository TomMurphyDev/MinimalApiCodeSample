namespace ItemStore; 

public class ItemDB
 {
   private static List<Item> _items = new List<Item>()
   {
     new Item{ Id=1, Name="Montemagno, Item shaped like a great mountain" },
     new Item{ Id=2, Name="The Galloway, Item shaped like a submarine, silent but deadly"},
     new Item{ Id=3, Name="The Noring, Item shaped like a Viking helmet, where's the mead"} 
   };

   public static List<Item> GetItems() 
   {
     return _items;
   } 

   public static Item ? GetItem(int id) 
   {
     return _items.SingleOrDefault(item => item.Id == id);
   } 

   public static Item CreateItem(Item item) 
   {
     _items.Add(item);
     return item;
   }

   public static Item UpdateItem(Item update) 
   {
     _items = _items.Select(item =>
     {
       if (item.Id == update.Id)
       {
         item.Name = update.Name;
       }
       return item;
     }).ToList();
     return update;
   }

   public static void RemoveItem(int id)
   {
     _items = _items.FindAll(item => item.Id == id).ToList();
   }
 }