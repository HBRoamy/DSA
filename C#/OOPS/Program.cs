class Program
{
    static void Main(string[] args)
    {
        // MyEventRaiser e = new MyEventRaiser();
        // Subscriber s = new Subscriber(1);
        // Subscriber s2 = new Subscriber(2);

        // e.priceChangedEvent+=s.OnPriceChange;
        // e.priceChangedEvent+=s2.OnPriceChange;
        // e.PriceChange(145);

        // ConcretePublisher pub = new ConcretePublisher(1);
        // Sub s1 = new Sub(1, pub);
        // Sub s2 = new Sub(2, pub);
        // pub.Subscribe(s1);
        // pub.Subscribe(s2);

        // //pub = new ConcretePublisher();
        // pub.f(2);


        ConcreteWorker cw = new ConcreteWorker();
        Deco1 d1 = new Deco1(cw);
        Deco2 d2 = new Deco2(d1);
        d2.someWork();

    }
}

interface x
{
    void fn();
}

interface y
{
    void fn();
}

class Z : x, y
{
    public void fn()
    {
        System.Console.WriteLine("LALALA");
    }
}

abstract class ClientNeeds
{
    public abstract void someWork();
}

class ConcreteWorker : ClientNeeds
{
    public override void someWork()
    {
        System.Console.WriteLine("I am base worker");
    }
}

abstract class absDeco : ClientNeeds
{
    protected ClientNeeds someRef;

    public absDeco(ClientNeeds ref1)
    {
        someRef = ref1;
    }

    public override void someWork()
    {
        someRef.someWork();
    }
}

class Deco1 : absDeco
{
    public Deco1(ClientNeeds ref1) : base(ref1)
    {
    }
    public override void someWork()
    {
        System.Console.WriteLine("Deco1");
        base.someWork();
    }
}
class Deco2 : absDeco
{
    public Deco2(ClientNeeds ref1) : base(ref1)
    {
    }
    public override void someWork()
    {
        System.Console.WriteLine("Deco2");

        base.someWork();
    }
}

class MyEventRaiser
{
    public delegate void PriceChangeHandler(int newPrice);
    public event PriceChangeHandler? priceChangedEvent;
    public MyEventRaiser()
    {
    }
    public void PriceChange(int newPrice)
    {
        OnPriceChange(newPrice);
    }

    protected virtual void OnPriceChange(int updatedPrice)
    {
        //Actual event-raising function
        priceChangedEvent!(updatedPrice);
        //priceChangedEvent.Invoke();
    }
}

class Subscriber
{
    int subscriberId;

    public Subscriber(int subscriberId)
    {
        this.subscriberId = subscriberId;

    }

    public void OnPriceChange(int newPrice)
    {
        System.Console.WriteLine($"Hey {subscriberId} got a new bid folks " + newPrice);
    }
}

abstract class AbstractPublisher
{
    List<AbstractSub> subs = new List<AbstractSub>();

    public void Subscribe(AbstractSub newSub)
    {
        System.Console.WriteLine("Subbed");
        subs.Add(newSub);
    }
    public void Unsubscribe(AbstractSub newSub)
    {
        System.Console.WriteLine("UnSUbbed");
        subs.Remove(newSub);
    }

    public void Notify()
    {
        System.Console.WriteLine("alert");
        foreach (var sub in subs)
        {
            sub.Update(this);
        }
    }
}

class ConcretePublisher : AbstractPublisher
{
    public int myState;
    public ConcretePublisher(int s)
    {
        myState = s;
    }

    public void f(int newState)
    {
        if (newState > myState)
        {
            myState = newState;
            base.Notify();
        }
    }
}

abstract class AbstractSub
{
    public abstract void Update(AbstractPublisher newSomething);
}

class Sub : AbstractSub
{
    int subId;
    AbstractPublisher state;
    public Sub(int id, AbstractPublisher state)
    {
        subId = id;
        this.state = state;
    }
    public override void Update(AbstractPublisher newSomething)
    {

        System.Console.WriteLine("Hey " + subId + " something happened: " + (newSomething as ConcretePublisher).myState);
    }
}

/*

class Program
{

    static void Main(string[] args)
    {
        forEvent myEvent = new forEvent();
        A a = new A();
        forEvent.eventName+=a.MyHandler;
        myEvent.Something(299);
       

    }
}
class forEvent
{
    public delegate void MyEventHandler(int x);
    public static event MyEventHandler eventName;

    public void Something(int x)
    {
        MyEventRaiser(x);
    }

    protected virtual void MyEventRaiser(int x)
    {
        eventName.Invoke(x);
    }
}

class A
{
    public void fn()
    {
        System.Console.WriteLine("A");
    }

    public void MyHandler(int x)
    {
        System.Console.WriteLine("Something happened " + x);
    }

    public virtual void fn2()// virtual says that this function might be overridden in its child classes
    {
        System.Console.WriteLine("A");
    }
}

class B : A
{
    public B()
    {

    }
    public new void fn()// B ka khudka function hai aur A se kuch lena dena nahi hai
                        // Bas name same hai isliye new use kiya
                        // if,in this case, We instantiate child object in base class reference
                        // then BASE CLASS fn() will be called
    {
        System.Console.WriteLine("B");
        // base.fn();//accessing the hidden base class method using upcasting
    }

    public override void fn2()// Here we voluntarily want to override the virtual function
                              // if,in this case, We instantiate child object in base class reference
                              // then Child CLASS fn2() will be called
    {
        System.Console.WriteLine("B");
    }

    public void fn3()
    {

    }
}
class C : B
{
    public override void fn2()
    {
        System.Console.WriteLine("from c");
    }
}
/*
 The override modifier may be used on virtual methods and must be used on abstract methods.
 This indicates for the compiler to use the last defined implementation of a method.
 Even if the method is called on a reference to the base class it will use the implementation
 overriding it.

 The new modifier instructs the compiler to use your child class implementation
 instead of the parent class implementation. Any code that is not referencing
 your class but the parent class will use the parent class implementation.

 "new" hides
 "override" overrides

 virtual: indicates that a method may be overriden by an inheritor
 override: overrides the functionality of a virtual method in a base class,
 providing different functionality.
 new: hides the original method (which doesn't have to be virtual), providing
 different functionality. This should only be used where it is absolutely necessary.
 When you hide a method, you can still access the original method by up casting to the base class. This is useful in some scenarios, but dangerous.
*/

