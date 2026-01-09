
record Category(int Id, string Name);

// Define Product class with nested Category
record Product(int Id, string Name, double Price, int Stock, Category Category);