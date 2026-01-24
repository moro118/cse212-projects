/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        //var cs = new CustomerService(10);
        //Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: he user shall specify the maximum size of the Customer Service Queue when it is created. 
        // Expected Result: If the size is invalid (less than or equal to 0) then the size shall default to 10.
        Console.WriteLine("Test 1");
        var cs1 = new CustomerService(0);
        Console.WriteLine(cs1);
       if (cs1.ToString() != "[size=0 max_size=10 => ]")
        {
            Console.WriteLine("Defect Found: Default size not set to 10 when initialized with 0");
        }
       else
        {
            Console.WriteLine("Test Passed");
        }
        var cs2 = new CustomerService(6);
        Console.WriteLine(cs2);
        if (cs2.ToString() != "[size=0 max_size=6 => ]")
        {
            Console.WriteLine("Defect Found: Size not set to 6 when initialized with 6");
        }
        else
        {
            Console.WriteLine("Test Passed");
        }
       

        Console.WriteLine("=================");

        // Test 2
        // Scenario: The AddNewCustomer method shall enqueue a new customer into the queue.
        // Expected Result: The customer should be added to the queue.
        Console.WriteLine("Test 2");
        var cs3 = new CustomerService(5);
        // use overload that doesn't read from Console
        cs3.AddNewCustomer("Alice", "A1", "Problema1");
        if (cs3.ToString().Contains("size=1"))
        {
            Console.WriteLine("Test Passed");
        }
        else
        {
            Console.WriteLine("Defect Found: Customer not added to the queue");
        }
        Console.WriteLine(cs3);

        // Defect(s) Found:

        Console.WriteLine("=================");

        // Add more Test Cases As Needed Below
        // Test 3
        // Scenario: If the queue is full when trying to add a customer
        // Expected Result: then an exception will be thrown.
        Console.WriteLine("Test 3");
        var cs4 = new CustomerService(1);

        try
        {
            cs4.AddNewCustomer("Alice", "A1", "Problema1");
            cs4.AddNewCustomer("Bob", "B2", "Problema2"); 
            Console.WriteLine("Defect Found: No exception when adding customer to full queue");
        }
        catch (InvalidOperationException ex)
        {
            if (ex.Message == "Maximum Number of Customers in Queue.")
                Console.WriteLine("Test Passed");
            else
                Console.WriteLine("Defect Found: Unexpected exception message: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Defect Found: Unexpected exception type: " + ex.GetType().Name);
        }

        Console.WriteLine(cs4);


        // Defect(s) Found:
        Console.WriteLine("=================");
        // Test 4
        // Scenario: The ServeCustomer function shall dequeue the next customer from the queue and display the details.
        // Expected Result: The customer details should be displayed and removed from the queue.
        Console.WriteLine("Test 4");
        var cs5 = new CustomerService(5);
        cs5.AddNewCustomer("Alice", "A1", "Problema1");
        // use ServeCustomer that returns the customer string
        var served = cs5.ServeCustomerAndReturnString();
        if (cs5.ToString().Contains("size=0"))
        {
            Console.WriteLine("Test Passed");
        }
        else
        {
            Console.WriteLine("Defect Found: Customer not served correctly from the queue");
        }
        Console.WriteLine("Served: " + served);
        Console.WriteLine(cs5);

        // Defect(s) Found:
        Console.WriteLine("=================");
        // Test 5
        // Scenario: If the queue is empty when trying to serve a customer, then an error message will be displayed.
        // Expected Result: An error (exception) should be thrown.
        Console.WriteLine("Test 5");
        var cs6 = new CustomerService(5);
        try
        {
            cs6.ServeCustomerAndReturnString();
            Console.WriteLine("Defect Found: No exception when serving from empty queue");
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Test Passed");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Defect Found: Unexpected exception type: " + ex.GetType().Name);
        }
        Console.WriteLine(cs6);

        // Defect(s) Found:
        Console.WriteLine("=================");

    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    public void AddNewCustomer(string name, string accountId, string problem)
    {
        if (_queue.Count >= _maxSize)
            throw new InvalidOperationException("Maximum Number of Customers in Queue.");
        var customer = new Customer(name.Trim(), accountId.Trim(), problem.Trim());
        _queue.Add(customer);
    }

  
    private void AddNewCustomer() {
        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        AddNewCustomer(name, accountId, problem);
    }

   
    public string ServeCustomerAndReturnString()
    {
        if (_queue.Count <= 0)
            throw new IndexOutOfRangeException();
        var customer = _queue[0];
        _queue.RemoveAt(0);
        return customer.ToString();
    }

    
    private void ServeCustomer() {
        if (_queue.Count <= 0)
            throw new IndexOutOfRangeException();
        var customer = _queue[0];
        _queue.RemoveAt(0);
        Console.WriteLine(customer);
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}