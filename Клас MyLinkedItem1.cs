public sealed class MyLinkedItem
{
    // Значення, що зберігається
    public int Value { get; set; }
    
    // Посилання на наступний елемент
    public MyLinkedItem? Next { get; internal set; }
    
    // Посилання на попередній елемент
    public MyLinkedItem? Prev { get; internal set; }

    // Конструктор
    public MyLinkedItem(int value)
    {
        Value = value;
        Next = null;
        Prev = null;
    }
}