using Microsoft.VisualBasic;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;

namespace Xacaton02
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Бот запущен");

            Console.WriteLine("Имя пользователя || Сообщение пользователя || Время отправки ");
            Console.ForegroundColor = ConsoleColor.White;


            var client = new TelegramBotClient("6034554077:AAFAZTEnnZUmdD6t3zs3_txpmfrBOJtHBlc");

            client.StartReceiving(Update, Error);




            Console.ReadKey();
        }


        async static Task Update(ITelegramBotClient botClient, Update update, CancellationToken token)
        {
            var message = update.Message;
            if (update.Message != null)
            {
                if (message.Text != null)
                {

                    switch (message.Text.ToLower())
                    {
                        case "/start":
                            StartButton("/start");
                            break;
                        case "вернуться":
                            StartButton("Вернуться");
                            break;

                        case "обучение📈":
                            TichButton();
                            break;

                        case "офис и сотрудники👥":
                            OfficAndSotr_Button();
                            break;

                        case "компания и продукты🏬":
                            CompanyButton();
                            break;

                        case "ваши обязанности":
                            await botClient.SendTextMessageAsync(message.Chat.Id, "Вы вступили к нам в коллектив и теперь вы будете работать над улучшением языка С--. Вашей команде будет приходить запрос на улучшение, доработку, создание новой функции в языке. И вы вместе с командой должны будете выполнить запрос, после нужно будет составить запрос на тест (пример составления запроса есть в меню). Надеемся вам понравится у нас работать.");
                            break;

                        case "почта для отправки":
                            await botClient.SendTextMessageAsync(message.Chat.Id, "Вот список почт для связи с отделом тестирования, отдел аналитики, главным менеджером: \nOtdelTest@yandex.ru \nOtdelAnalit@yandex.ru \nManager312@yandex.ru");
                            break;

                        case "пример оформления запроса":
                            await botClient.SendTextMessageAsync(message.Chat.Id, "Оформить запрос очень легко, вам нужно будет заполнить каждый пункт и отправить на почту в отдел тестирования. \nПример офрмления: \n1) Цель изменения/разработки \n2) Что было изменено/добавлено \n3) Добавочная информация (если она имеется)");
                            break;

                        case "офис":
                            Photo("офис");
                            break;
                        case "коллеги":
                            Photo("коллеги");
                            break;
                        case "адрес офиса":
                            await botClient.SendTextMessageAsync(message.Chat.Id, "Офис в БЦ \"Бенуа\"");
                            break;

                        case "продукты компании":
                            await botClient.SendTextMessageAsync(message.Chat.Id, "Наша компания создала и продолжает улучшать язык C--, СУБД SQLS, пакет офисных программ, в него входит текстовый процессор Wort, табличный процессор Essel");
                            break;

                        case "самый популярный продукт":
                            await botClient.SendTextMessageAsync(message.Chat.Id, "Самый популярный продукт нашей компании - это операционная система Окно. Ей пользуются большая часть населения земли. Вышедшие версии: Окно 1, Окно 2, Окно 3");
                            break;

                        case "история компании":
                            await botClient.SendTextMessageAsync(message.Chat.Id, "Наша компания появилась в 2023 году и сразу стала популярной.");
                            break;

                    }





                }
            }



            async void StartButton(string a)
            {
                string[][] strings = new[] {
                new[]{ "Обучение📈","Офис и сотрудники👥"},
                 new[]{ "Компания и продукты🏬" }
                };

                ReplyKeyboardMarkup keyboardMarkup = strings;
                keyboardMarkup.ResizeKeyboard = true;
                if (a == "/start")
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Здравствуйте, я бот, который должен помочь вам в обучении своим должностям, знакомству с офисом, коллективом и продукцией нашей компании", replyMarkup: keyboardMarkup);
                if (a == "Вернуться")
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите то, о чём вам рассказать.", replyMarkup: keyboardMarkup);
                return;
            }
            async void TichButton()
            {
                string[][] strings = new[]
                {
                    new[]{"Ваши обязанности", "Почта для отправки", "Пример оформления запроса", "Вернуться"}
                };
                ReplyKeyboardMarkup keyboardMarkup = strings;
                keyboardMarkup.ResizeKeyboard = true;
                await botClient.SendTextMessageAsync(message.Chat.Id, "Позвольте объяснить вам задачи которые вы будете выполнять и полезную в дальнейшем информацию", replyMarkup: keyboardMarkup);
            }

            async void OfficAndSotr_Button()
            {
                string[][] strings = new[] {
                new[]{ "Офис","Коллеги"},
                 new[]{ "Адрес офиса", "Вернуться" }
                };

                ReplyKeyboardMarkup keyboardMarkup = strings;
                keyboardMarkup.ResizeKeyboard = true;
                await botClient.SendTextMessageAsync(message.Chat.Id, "Для успешной работы, нужно знать где и с кем работаешь.", replyMarkup: keyboardMarkup);


                return;
            }

            async void CompanyButton()
            {
                string[][] strings = new[]
                {
                    new[]{"Продукты компании", "Самый популярный продукт"},
                    new[]{"История компании", "Вернуться"}
                };
                ReplyKeyboardMarkup keyboardMarkup = strings;
                keyboardMarkup.ResizeKeyboard = true;
                await botClient.SendTextMessageAsync(message.Chat.Id, "Давайте расскажу вам о нашей компании.", replyMarkup: keyboardMarkup);
                return;
            }
            async void Photo(string a)
            {
                if (a == "офис")
                {
                    await using Stream stream = System.IO.File.OpenRead(@"Resurses\Offis\RabMesto.jpg");
                    await botClient.SendPhotoAsync(message.Chat.Id, new InputOnlineFile(stream, fileName: "RabMesto.jpg"), caption: "Это твое будущее рабочее место.");

                    await using Stream stream1 = System.IO.File.OpenRead(@"Resurses\Offis\Relax.jpg");
                    await botClient.SendPhotoAsync(message.Chat.Id, new InputOnlineFile(stream1, fileName: "Relax.jpg"), caption: "Тут ты сможешь поиграть с колегами в тенис, плойку либо же просто почитать книги");

                    await using Stream stream2 = System.IO.File.OpenRead(@"Resurses\Offis\Sbor.jpg");
                    await botClient.SendPhotoAsync(message.Chat.Id, new InputOnlineFile(stream2, fileName: "Sbor.jpg"), caption: "Тут ты обслуждаем дальнейшее движение компании и ее направление");
                }

                if (a == "коллеги")
                {
                    await using Stream stream = System.IO.File.OpenRead(@"Resurses\Piple\ocr1.jpg");
                    await botClient.SendPhotoAsync(message.Chat.Id, new InputOnlineFile(stream, fileName: "ocr1.jpg"), caption: "Коментарий:\"Привет я главый контент менаджер нашей компании \"");

                    await using Stream stream1 = System.IO.File.OpenRead(@"Resurses\Piple\ocr2.jpg");
                    await botClient.SendPhotoAsync(message.Chat.Id, new InputOnlineFile(stream1, fileName: "ocr1.jpg"), caption: "Коментарий:\"Привет я главный системный админестратор \"");

                    await using Stream stream2 = System.IO.File.OpenRead(@"Resurses\Piple\ocr3.jpg");
                    await botClient.SendPhotoAsync(message.Chat.Id, new InputOnlineFile(stream2, fileName: "ocr3.jpg"), caption: "Коментарий:\"Привет я fullStak разработчик \"");

                }
            }
        }

        private static Task Error(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
        {

            throw new NotImplementedException();


        }
    }
}