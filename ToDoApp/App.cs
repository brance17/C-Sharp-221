using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp
{
    public class App
    {

        ConsoleUtils consoleUtils;
        ItemRepository itemRepository;

        public App()
        {
            consoleUtils = new ConsoleUtils();
            itemRepository = new ItemRepository();

        }

        public void Start()
        {

            bool isRunning = true;

            while (isRunning)
            {
                var response = consoleUtils.UtilGetUserOption();
                switch (response)
                {

                    case 1: //add items
                        itemRepository.AddItem(consoleUtils.UtilAddItem());
                        break;

                    case 2: // delete items
                        if (itemRepository.CheckItem(consoleUtils.UtilGetItem()) == true)
                        {
                            itemRepository.RemoveItem(consoleUtils.UtilGetItem());
                        }
                        else
                        {
                            consoleUtils.UtilError();
                        }

                        break;

                    case 3: // mark items as complete

                        if (itemRepository.CheckItem(consoleUtils.UtilGetItem()) == true)
                        {
                            itemRepository.MarkDoneItem(consoleUtils.UtilGetItem());
                        }
                        else
                        {
                            consoleUtils.UtilError();
                        }
                        break;

                    case 4: //lists all items
                        consoleUtils.UtilPrintList(itemRepository.GetAllItem());
                        break;

                    case 5: //lists all done items
                        consoleUtils.UtilPrintList(itemRepository.GetDoneItem());
                        break;

                    case 6: //lists all pending items
                        consoleUtils.UtilPrintList(itemRepository.GetPendingItem());
                        break;

                    case 7:
                        isRunning = false;
                        break;

                    case 8:
                        consoleUtils.UtilError();
                        break;
                }
            }

        }
    }
}