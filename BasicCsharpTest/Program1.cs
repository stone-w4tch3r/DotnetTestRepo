﻿#if false
var a = "str";
var b = a;
var c = a;
var d = a;
//Console.WriteLine(a + b + c + d);
a = a + "ing";
b = "dtr";
//Console.WriteLine(a + b + c + d);

Do();

void Do()
{
    var vasya = new Person() { Name = "Вася" };
    var school = new School() { Name = "Школа №1"};
    school.Run(vasya);
    vasya.Run();
    Console.WriteLine(school);
    Console.WriteLine(vasya);
}

public record Person
{
    public Person Parent { get; set; } = new Person() { Name = "Мама Васи" };
    public string Name { get; set; }
    public void Run()
    {
        Parent = new Person() { Name = "Папа Васи" };
    }
}

public record Cat
{
    public string Name { get; set; }
    public void Run()
    {
        Name = "Барсик";
    }
}

public record School
{
    public Person Director { get; set; }
    public string Name { get; set; }
    public void Run(Person person)
    {
        Director = person;
        Console.WriteLine("Director is " + Director.Name);
    }
}

//Союз нерушимый республик свободных
//Сплотила навеки Великая Русь.
//Да здравствует созданный волей народов
//Единый, могучий Советский Союз!
//
//Славься, Отечество наше свободное,
//Дружбы народов надёжный оплот!
//Знамя советское, знамя народное
//Пусть от победы к победе ведёт!
//
//Славься, страна! Мы гордимся тобой,
//Как звездой сиянь на небеса нам,
//И пусть вспоминают твои дети
//Твой геройский подвиг и славу.
//
//Славься, Отечество наше свободное,
//Дружбы народов надёжный оплот!
//Знамя советское, знамя народное
//Пусть от победы к победе ведёт!
//  
//Славься, страна! Мы гордимся тобой,
//Как звездой сиянь на небеса нам,
//И пусть вспоминают твои дети
//Твой геройский подвиг и славу.
//  
//
//
//Маленькой елочке холодно зимой
//И она взяла и сказала:
//«Мама, мама, я хочу в садик!»
//И мама ей ответила:
//«Нет, малышка, не ходи в садик,
//Ты ещё маленькая,
//Иди в школу, там тебе будет лучше!»
//
//Маленькая елочка в школу ходила
//И училась, училась, училась,
//И училась, училась, училась,
//И училась, училась, училась,
//И училась, училась, училась,
//И училась, училась, училась,
//И училась, училась, училась,
//И училась, училась, училась,
//И училась, училась, училась,
//И что было? Всё училась!
//
//И вот однажды елочка сказала:
//Что же будет дальше?
//И мама ей ответила:
//«Ты будешь учиться, учиться, учиться,
//И учиться, учиться, учиться,
//И учиться, учиться, учиться,
//И учиться, учиться, учиться,
//И учиться, учиться, учиться,
//До тех пор, пока не станешь
//Учительницей в школе!»
//
//И вот елочка стала учительницей
//И учила, учила, учила,
//И учила, учила, учила,
//И учила, учила, учила,
//И учила, учила, учила,
//И учила, учила, учила,
//И учила, учила, учила,
//И учила, учила, учила,
//И учила, учила, учила,
//Но однажды дедушка елочки
//Сказал: «Мама, мама, я хочу в садик!»
//
//И мама ему ответила:
//Какой садик? Ты же ещё маленький!
//Сиди дома, учись, учись, учись,
//И учись, учись, учись,
//И учись, учись, учись,
//И учись, учись, учись,
//И учись, учись, учись,
//И учись, учись, учись,
//И учись, учись, учись,
//И учись, учись, учись,
//И учись, учись, учись,
//И учись, учись, учись,
//И учись, учись, учись,
//Пока не станешь ученым!
//
//И вот дедушка стал ученым
//И учился, учился, учился,
//И учился, учился, учился,
//И учился, учился, учился,
//И учился, учился, учился,
//А потом он умер.
//
//И вот елочка сказала:
//Что же будет дальше?
//И мама ей ответила:
//«Ты будешь учиться, учиться, учиться,
//И учиться, учиться, учиться,
//И учиться, учиться, учиться,
//И учиться, учиться, учиться,
//И учиться, учиться, учиться,
//До тех пор, пока не станешь
//Мертвой!»
//
//И вот елочка стала мертвой
//И умерла, умерла, умерла,
//И умерла, умерла, умерла,
//И умерла, умерла, умерла,
//И умерла, умерла, умерла,
//Спустя много лет.
//
//И вот попала елочка в могилу
//И умерла, умерла, умерла,
//И умерла, умерла, умерла,
//И умерла, умерла, умерла,
//И умерла, умерла, умерла,
//Лежа в могиле.
//
//И воскресла елочка из могилы, 
//И умерла, умерла, умерла,
//И умерла, умерла, умерла,
//И умерла, умерла, умерла,
//И умерла, умерла, умерла,
//Уже настолько, что ей стало
//Очень страшно.
//
//Попала она на небо
//И встретила у небесной врата
//Святого Санта Клауса.
//
//И Санта Клаус сказал ей:
//«Ты что, елочка, ты что, елочка,
//Ты что, елочка, ты что, елочка,
//Ты что, елочка, ты что, елочка,
//Ты что, елочка, ты что, елочка,
//Что ты тут делаешь?»
//
//И елочка сказала:
//«Я хочу стать Санта Клаусом!»
//
//И Санта Клаус сказал ей:
//«Ты что, елочка, ты что, елочка,
//Ты что, елочка, ты что, елочка,
//Ты что, елочка, ты что, елочка,
//Ты что, елочка, ты что, елочка,
//Я тебе не скажу, как стать Санта Клаусом,
//Но я скажу, как стать Санта Клаусом,
//Но я скажу, как стать Санта Клаусом,
//Но я скажу, как стать Санта Клаусом,
//Но я скажу, как стать Санта Клаусом,
//Но я скажу, как стать Санта Клаусом,
//Если ты будешь учиться, учиться, учиться,
//Если ты будешь учиться, учиться, учиться,
//Если ты будешь учиться, учиться, учиться,
//Если ты будешь учиться, учиться, учиться,
//Со мной!»
//
//И елочка сказала:
//«Я буду учиться, учиться, учиться,
//Я буду учиться, учиться, учиться,
//Я буду учиться, учиться, учиться,
//Я буду учиться, учиться, учиться,
//Со Санта Клаусом!»
//
//
//
//
//
//Through the gates of hell
//As we make our way to heaven
//Through the nazi lines
//Primo viktoria
//
//
//
//Отче наш иже еси на небеси
//






//compute product of two digits
#endif