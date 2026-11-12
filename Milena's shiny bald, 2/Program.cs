// Milena Aquino Ramos 2026-1036
// Project: Hair Salon Appointment Management System
// Description: A console application designed to manage customers,
// services, and appointments. It allows users to create, view, modify, and cancel appointments.
// #yawey

List<int> ids = new List<int>();
Dictionary<int, string> customers = new Dictionary<int, string>();
Dictionary<int, string> phones = new Dictionary<int, string>();
Dictionary<int, string> services = new Dictionary<int, string>();
Dictionary<int, string> dates = new Dictionary<int, string>();
Dictionary<int, string> times = new Dictionary<int, string>();
Dictionary<int, bool> activeAppointments = new Dictionary<int, bool>();

bool exit = false;
bool dataIsValid = true;
bool match = false, found = false, conflict = false, newActive = false;

int option = 0, searchOption = 0, searchId = 0,
    modifyId = 0, modifyOption = 0, deleteId = 0;

int nextId = 1;

string input = "", status = "", searchText = "";
string newText = "", newDateText = "", newTimeText = "";
string customerName = "", phoneNumber = "", service = "";

while (!exit)
{
    try
    {
        Console.WriteLine(
            "\n--♡-- WELCOME TO MILENA'S APPOINTMENT SCHEDULE --♡--" +
            "\n++♥++ SHINY BALD ++♥++" +
            "\n1. Add Appointment ʚɞ" +
            "\n2. Search Appointment ʚɞ" +
            "\n3. Modify Appointment ʚɞ" +
            "\n4. Delete Appointment ʚɞ" +
            "\n5. List Appointments ʚɞ" +
            "\n6. Exit ʚɞ"
        );

        Console.Write("Select an option ୨୧ : ");

        if (!int.TryParse(Console.ReadLine(), out option))
        {
            Console.WriteLine("Invalid option.");
            continue;
        }

        switch (option)
        {
            // add
            case 1:
                {
                    customerName = "";
                    phoneNumber = "";
                    service = "";
                    newDateText = "";
                    newTimeText = "";

                    Console.WriteLine("\n--- Add Appointment ---");

                    while (string.IsNullOrWhiteSpace(customerName))
                    {
                        Console.Write("Insert Customer name: ");
                        customerName = Console.ReadLine()!;
                    }

                    while (string.IsNullOrWhiteSpace(phoneNumber))
                    {
                        Console.Write("Insert Phone number: ");
                        phoneNumber = Console.ReadLine()!;
                    }

                    while (string.IsNullOrWhiteSpace(service))
                    {
                        Console.Write("What service do you need?: ");
                        service = Console.ReadLine()!;
                    }

                    while (string.IsNullOrWhiteSpace(newDateText))
                    {
                        Console.Write("Insert the date (dd/MM/yyyy): ");
                        newDateText = Console.ReadLine()!;
                    }

                    while (string.IsNullOrWhiteSpace(newTimeText))
                    {
                        Console.Write("Set the time (HH:mm): ");
                        newTimeText = Console.ReadLine()!;
                    }

                    conflict = false;

                    foreach (int appointmentId in ids)
                    {
                        if (activeAppointments[appointmentId] &&
                            dates[appointmentId] == newDateText &&
                            times[appointmentId] == newTimeText)
                        {
                            conflict = true;
                        }
                    }

                    if (conflict)
                    {
                        Console.WriteLine("Error: there is already an active appointment on that date and time.");
                    }
                    else
                    {
                        ids.Add(nextId);
                        customers.Add(nextId, customerName);
                        phones.Add(nextId, phoneNumber);
                        services.Add(nextId, service);
                        dates.Add(nextId, newDateText);
                        times.Add(nextId, newTimeText);
                        activeAppointments.Add(nextId, true);

                        Console.WriteLine("Appointment added successfully. ID: " + nextId);
                        nextId++;
                    }

                    break;
                }

            // search
            case 2:
                {
                    Console.WriteLine(
                        "\n--- Search Appointment ---" +
                        "\n1. Search by ID" +
                        "\n2. Search by Customer Name" +
                        "\n3. Search by Service" +
                        "\n4. Search by Date"
                    );

                    Console.Write("Select a search option: ");

                    if (!int.TryParse(Console.ReadLine(), out searchOption))
                    {
                        Console.WriteLine("Invalid search option.");
                        break;
                    }

                    dataIsValid = true;
                    searchText = "";

                    if (searchOption == 1)
                    {
                        Console.Write("Enter the ID: ");

                        if (!int.TryParse(Console.ReadLine(), out searchId))
                        {
                            Console.WriteLine("Invalid ID.");
                            dataIsValid = false;
                        }
                    }
                    else if (searchOption == 2)
                    {
                        while (string.IsNullOrWhiteSpace(searchText))
                        {
                            Console.Write("Enter the customer name: ");
                            searchText = Console.ReadLine()!;
                        }
                    }
                    else if (searchOption == 3)
                    {
                        while (string.IsNullOrWhiteSpace(searchText))
                        {
                            Console.Write("Enter the service: ");
                            searchText = Console.ReadLine()!;
                        }
                    }
                    else if (searchOption == 4)
                    {
                        while (string.IsNullOrWhiteSpace(searchText))
                        {
                            Console.Write("Enter the date (dd/MM/yyyy): ");
                            searchText = Console.ReadLine()!;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid search option. Please choose between 1 and 4.");
                        dataIsValid = false;
                    }

                    if (dataIsValid)
                    {
                        found = false;

                        Console.WriteLine("\n--- Search Results ---");

                        foreach (int appointmentId in ids)
                        {
                            match = false;

                            if (searchOption == 1 && appointmentId == searchId)
                            {
                                match = true;
                            }
                            else if (searchOption == 2 &&
                                     customers[appointmentId] == searchText)
                            {
                                match = true;
                            }
                            else if (searchOption == 3 &&
                                     services[appointmentId] == searchText)
                            {
                                match = true;
                            }
                            else if (searchOption == 4 &&
                                     dates[appointmentId] == searchText)
                            {
                                match = true;
                            }

                            if (match)
                            {
                                found = true;

                                if (activeAppointments[appointmentId])
                                {
                                    status = "Active";
                                }
                                else
                                {
                                    status = "Not active";
                                }

                                Console.WriteLine(
                                    "ID: " + appointmentId +
                                    "\nCustomer: " + customers[appointmentId] +
                                    "\nPhone: " + phones[appointmentId] +
                                    "\nService: " + services[appointmentId] +
                                    "\nDate: " + dates[appointmentId] +
                                    "\nTime: " + times[appointmentId] +
                                    "\nStatus: " + status +
                                    "\n------------------------"
                                );
                            }
                        }

                        if (!found)
                        {
                            Console.WriteLine("No appointments found.");
                        }
                    }

                    break;
                }

            // modify
            case 3:
                {
                    Console.WriteLine(
                        "\n--- Modify Appointment ---" +
                        "\nEnter the ID of the appointment to modify: "
                    );

                    if (!int.TryParse(Console.ReadLine(), out modifyId))
                    {
                        Console.WriteLine("Invalid ID.");
                        break;
                    }

                    if (!customers.ContainsKey(modifyId))
                    {
                        Console.WriteLine("Error: no appointment found with that ID.");
                    }
                    else
                    {
                        if (activeAppointments[modifyId])
                        {
                            status = "Active";
                        }
                        else
                        {
                            status = "Not active";
                        }

                        Console.WriteLine(
                            "\nWhat do you want to modify?" +
                            "\n1. Customer Name (current: " + customers[modifyId] + ")" +
                            "\n2. Phone Number (current: " + phones[modifyId] + ")" +
                            "\n3. Service (current: " + services[modifyId] + ")" +
                            "\n4. Date (current: " + dates[modifyId] + ")" +
                            "\n5. Time (current: " + times[modifyId] + ")" +
                            "\n6. Status (current: " + status + ")"
                        );

                        Console.Write("Select an option: ");

                        if (!int.TryParse(Console.ReadLine(), out modifyOption))
                        {
                            Console.WriteLine("Invalid option.");
                            break;
                        }

                        newText = "";
                        newDateText = dates[modifyId];
                        newTimeText = times[modifyId];
                        newActive = activeAppointments[modifyId];
                        dataIsValid = true;

                        if (modifyOption == 1)
                        {
                            Console.Write("New customer name: ");
                            newText = Console.ReadLine()!;
                        }
                        else if (modifyOption == 2)
                        {
                            Console.Write("New phone number: ");
                            newText = Console.ReadLine()!;
                        }
                        else if (modifyOption == 3)
                        {
                            Console.Write("New service: ");
                            newText = Console.ReadLine()!;
                        }
                        else if (modifyOption == 4)
                        {
                            Console.Write("New date (dd/MM/yyyy): ");
                            newDateText = Console.ReadLine()!;
                        }
                        else if (modifyOption == 5)
                        {
                            Console.Write("New time (HH:mm): ");
                            newTimeText = Console.ReadLine()!;
                        }
                        else if (modifyOption == 6)
                        {
                            newActive = !newActive;
                        }
                        else
                        {
                            Console.WriteLine("Invalid option. Please choose between 1 and 6.");
                            dataIsValid = false;
                        }

                        if (dataIsValid && newActive && modifyOption >= 4)
                        {
                            conflict = false;

                            foreach (int appointmentId in ids)
                            {
                                if (appointmentId != modifyId &&
                                    activeAppointments[appointmentId] &&
                                    dates[appointmentId] == newDateText &&
                                    times[appointmentId] == newTimeText)
                                {
                                    conflict = true;
                                }
                            }

                            if (conflict)
                            {
                                Console.WriteLine("Error: there is already an active appointment on that date and time.");
                                dataIsValid = false;
                            }
                        }

                        if (dataIsValid)
                        {
                            if (modifyOption == 1)
                            {
                                customers[modifyId] = newText;
                                Console.WriteLine("Customer name updated successfully.");
                            }
                            else if (modifyOption == 2)
                            {
                                phones[modifyId] = newText;
                                Console.WriteLine("Phone number updated successfully.");
                            }
                            else if (modifyOption == 3)
                            {
                                services[modifyId] = newText;
                                Console.WriteLine("Service updated successfully.");
                            }
                            else if (modifyOption == 4)
                            {
                                dates[modifyId] = newDateText;
                                Console.WriteLine("Date updated successfully.");
                            }
                            else if (modifyOption == 5)
                            {
                                times[modifyId] = newTimeText;
                                Console.WriteLine("Time updated successfully.");
                            }
                            else if (modifyOption == 6)
                            {
                                activeAppointments[modifyId] = newActive;

                                if (newActive)
                                {
                                    status = "Active";
                                }
                                else
                                {
                                    status = "Not active";
                                }

                                Console.WriteLine(
                                    "Status updated successfully. The appointment is now: " +
                                    status
                                );
                            }
                        }
                    }

                    break;
                }

            // delete
            case 4:
                {
                    Console.WriteLine(
                        "\n--- Delete Appointment ---" +
                        "\nEnter the ID of the appointment to delete: "
                    );

                    if (!int.TryParse(Console.ReadLine(), out deleteId))
                    {
                        Console.WriteLine("Invalid ID.");
                        break;
                    }

                    if (!customers.ContainsKey(deleteId))
                    {
                        Console.WriteLine("Error: no appointment found with that ID.");
                    }
                    else
                    {

                        Console.WriteLine(
                        "\nAppointment to delete:" +
                        "\nID: " + deleteId +
                        "\nCustomer: " + customers[deleteId] +
                        "\nService: " + services[deleteId] +
                        "\nDate: " + dates[deleteId] +
                        "\nTime: " + times[deleteId]
                        );

                        Console.Write("Are you sure you want to delete it? (y/n): ");

                        input = Console.ReadLine()!;

                        if (input == "y" || input == "Y")
                        {
                            ids.Remove(deleteId);
                            customers.Remove(deleteId);
                            phones.Remove(deleteId);
                            services.Remove(deleteId);
                            dates.Remove(deleteId);
                            times.Remove(deleteId);
                            activeAppointments.Remove(deleteId);

                            Console.WriteLine("Appointment deleted successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Deletion cancelled.");
                        }
                    }

                    break;
                }

            // list
            case 5:
                {
                    Console.WriteLine("\n--- List of Appointments ---");

                    if (ids.Count == 0)
                    {
                        Console.WriteLine("There are no appointments registered.");
                    }
                    else
                    {
                        foreach (int appointmentId in ids)
                        {
                            if (activeAppointments[appointmentId])
                            {
                                status = "Active";
                            }
                            else
                            {
                                status = "Not active";
                            }

                            Console.WriteLine(
                                "ID: " + appointmentId +
                                "\nCustomer: " + customers[appointmentId] +
                                "\nPhone: " + phones[appointmentId] +
                                "\nService: " + services[appointmentId] +
                                "\nDate: " + dates[appointmentId] +
                                "\nTime: " + times[appointmentId] +
                                "\nStatus: " + status +
                                "\n------------------------"
                            );
                        }

                        Console.WriteLine("Total appointments: " + ids.Count);
                    }

                    break;
                }

            // exit
            case 6:
                {
                    Console.WriteLine("Goodbye, i hope you enjoy my program, i'll wait for you again! XOXO!!!");
                    exit = true;
                    break;
                }

            default:
                {
                    Console.WriteLine("Invalid option. Please choose between 1 and 6.");
                    break;
                }
        }

        if (!exit)
        {
            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("\nAn unexpected error occurred.");
        Console.WriteLine("Error details: " + ex.Message);

        Console.WriteLine("\nPress Enter to continue...");
        Console.ReadLine();
    }
}
