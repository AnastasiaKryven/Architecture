using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Excel;
using DataControl;
using Excel = Microsoft.Office.Interop.Excel;
#pragma warning disable CS0105 // Директива using для "System" ранее встречалась в этом пространстве имен
using System;
#pragma warning restore CS0105 // Директива using для "System" ранее встречалась в этом пространстве имен
using System.IO;

namespace Main
{
    public partial class MainForm
    {
        public void SaveWordTable(string filename)
        {

            Word.Application wdApp = new Word.Application();
            Word.Document doc = wdApp.Documents.Add();

            //Добавляем таблицу в начало второго параграфа
            Object defaultTableBehavior =
             Word.WdDefaultTableBehavior.wdWord9TableBehavior;
            Object autoFitBehavior =
             Word.WdAutoFitBehavior.wdAutoFitWindow;

            Word.Paragraph dhp = doc.Paragraphs.Add();
            Word.Range d = dhp.Range;
            Word.Table Bank = doc.Content.Tables.Add(d, data.Banks.Count + 1, 6, ref defaultTableBehavior, ref autoFitBehavior);
            Bank.Borders.Enable = 1;
            Bank.Rows[1].Cells[1].Range.Text = "Название";
            Bank.Rows[1].Cells[2].Range.Text = "Mfo";
            Bank.Rows[1].Cells[3].Range.Text = "Address";
            Bank.Rows[1].Cells[4].Range.Text = "Type";
            Bank.Rows[1].Cells[5].Range.Text = "PhoneNumber";
            int i = 2;
            foreach (Data.Bank dh in data.Banks)
            {
                Bank.Rows[i].Cells[1].Range.Text = dh.BankName;
                Bank.Rows[i].Cells[2].Range.Text = dh.MFO.ToString();
                Bank.Rows[i].Cells[3].Range.Text = dh.Adress.ToString();
                Bank.Rows[i].Cells[4].Range.Text = dh.BankType.ToString();
                Bank.Rows[i].Cells[5].Range.Text = dh.NumberPhone.ToString();
                i++;
            }
            //Сдвигаемся вниз в конец документа
            object unit;
            object extend;
            unit = Word.WdUnits.wdStory;
            extend = Word.WdMovementType.wdMove;
            wdApp.Selection.EndKey(ref unit, ref extend);

            Word.Paragraph ihp = doc.Paragraphs.Add();
            Word.Range ing = ihp.Range;

            Word.Table Currency = doc.Content.Tables.Add(ing, data.Types.Count + 1, 4, ref defaultTableBehavior, ref autoFitBehavior);
            Currency.Borders.Enable = 1;
            Currency.Rows[1].Cells[1].Range.Text = "Название";
            Currency.Rows[1].Cells[2].Range.Text = "Номер";
            Currency.Rows[1].Cells[3].Range.Text = "Сокращение";
            i = 2;
            foreach (Data.Type dh in data.Types)
            {
                Currency.Rows[i].Cells[1].Range.Text = dh.NameOfCurrency;
                Currency.Rows[i].Cells[2].Range.Text = dh.NumbOfCurrency.ToString();
                Currency.Rows[i].Cells[3].Range.Text = dh.ShortNameOfCurrency.ToString();
                i++;
            }
            //Сдвигаемся вниз в конец документа
            object unit1;
            object extend1;
            unit1 = Word.WdUnits.wdStory;
            extend1 = Word.WdMovementType.wdMove;
            wdApp.Selection.EndKey(ref unit1, ref extend1);

            Word.Paragraph chp = doc.Paragraphs.Add();
            Word.Range cng = chp.Range;
            Word.Table LogEntry = doc.Content.Tables.Add(cng, data.Logs.Count + 1, 5, ref defaultTableBehavior, ref autoFitBehavior);
            LogEntry.Borders.Enable = 1;
            LogEntry.Rows[1].Cells[1].Range.Text = "MFO";
            LogEntry.Rows[1].Cells[2].Range.Text = "Валюта";
            LogEntry.Rows[1].Cells[3].Range.Text = "Date";
            LogEntry.Rows[1].Cells[4].Range.Text = "SalesRate";
            LogEntry.Rows[1].Cells[5].Range.Text = "PurchaseRate";
            i = 2;
            foreach (Data.Log dh in data.Logs)
            {
                LogEntry.Rows[i].Cells[1].Range.Text = dh.MFO.ToString();
                LogEntry.Rows[i].Cells[2].Range.Text = dh.NumbOfCurrency.ToString();
                LogEntry.Rows[i].Cells[3].Range.Text = dh.Date.ToString();
                LogEntry.Rows[i].Cells[4].Range.Text = dh.SaleCurrency.ToString();
                LogEntry.Rows[i].Cells[5].Range.Text = dh.BuyCurrency.ToString();
                i++;
            }

            doc.SaveAs(filename);
            doc.Close();
            wdApp.Quit();
            ReleaseObject(Bank);
            ReleaseObject(Currency);
            ReleaseObject(LogEntry);
            ReleaseObject(doc);
            ReleaseObject(wdApp);
        }
        public void SaveWord(string filename)
        {
            Word.Application wdApp = new Word.Application();
            Word.Document doc = wdApp.Documents.Add();

            Word.Paragraph Bank = doc.Content.Paragraphs.Add();

            Bank.Range.ListFormat.ApplyBulletDefault();
            foreach (Data.Bank d in data.Banks)
            {
                string bulletItem = $"Name: \"{d.BankName}\", Address: \"{d.Adress}\", " +
                    $"MFO: \"{d.MFO}\",Тип: \"{d.BankType}\", Номер: \"{d.NumberPhone.ToString()}\"";
                bulletItem = bulletItem + "\n";
                Bank.Range.InsertBefore(bulletItem);
            }

            Word.Paragraph Currency = doc.Content.Paragraphs.Add();

            Currency.Range.ListFormat.ApplyBulletDefault();
            foreach (Data.Type d in data.Types)
            {
                string bulletItem = $"Name: \"{d.NameOfCurrency}\", NumCurrency: \"{d.NumbOfCurrency}\", " +
                    $",Shortname: \"{d.ShortNameOfCurrency}\"";
                bulletItem = bulletItem + "\n";
                Currency.Range.InsertBefore(bulletItem);
            }

            Word.Paragraph LogEntry = doc.Content.Paragraphs.Add();

            LogEntry.Range.ListFormat.ApplyBulletDefault();
            foreach (Data.Log d in data.Logs)
            {
                string bulletItem = $"MFO: \"{d.MFO}\", NumbOfCurrency: \"{d.NumbOfCurrency}\", Date: \"{d.Date.ToString()}\"" +
                    $",PurchaseRate: \"{d.BuyCurrency}\" , SalesRate: \"{d.SaleCurrency}\"";

                bulletItem = bulletItem + "\n";
                LogEntry.Range.InsertBefore(bulletItem);
            }

            doc.SaveAs(filename);
            doc.Close();
            wdApp.Quit();
            ReleaseObject(Bank);
            ReleaseObject(Currency);
            ReleaseObject(LogEntry);
            ReleaseObject(doc);
            ReleaseObject(wdApp);
        }

        void ReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception)
            {
                obj = null;
            }
            GC.Collect();
        }

        public void SaveExcel(string filename)
        {
            Excel.Application xlApp = new Excel.Application();
            Workbook xlBook = xlApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            Worksheet xlSheet = (Worksheet)xlBook.Worksheets.Item[1];

            xlSheet.Cells[1, 1] = "Список Банков:";
            xlSheet.Cells[2, 1] = "Название";
            xlSheet.Cells[2, 2] = "МФО";
            xlSheet.Cells[2, 3] = "Адрес";
            xlSheet.Cells[2, 4] = "Номер Тел";
            xlSheet.Cells[2, 5] = "Тип";

            int i = 3;
            foreach (Data.Bank d in data.Banks)
            {
                xlSheet.Cells[i, 1] = d.BankName;
                xlSheet.Cells[i, 2] = d.MFO;
                xlSheet.Cells[i, 3] = d.Adress;
                xlSheet.Cells[i, 4] = d.NumberPhone.ToString();
                xlSheet.Cells[i, 5] = d.BankType;
                i++;
            }
            i = 3;
            xlSheet.Cells[1, 6] = "Список Валют:";
            xlSheet.Cells[2, 6] = "Номер валюты";
            xlSheet.Cells[2, 7] = "Название";
            xlSheet.Cells[2, 8] = "Сокращение";

            foreach (Data.Type d in data.Types)
            {
                xlSheet.Cells[i, 6] = d.NumbOfCurrency;
                xlSheet.Cells[i, 7] = d.NameOfCurrency;
                xlSheet.Cells[i, 8] = d.ShortNameOfCurrency;
                i++;
            }
            i = 3;
            xlSheet.Cells[1, 10] = "Журнал Курсов:";
            xlSheet.Cells[2, 10] = "МФО банка";
            xlSheet.Cells[2, 11] = "Номер валюты";
            xlSheet.Cells[2, 12] = "Дата";
            xlSheet.Cells[2, 13] = "Д.Покупки";
            xlSheet.Cells[2, 14] = "Д.Продажи";


            foreach (Data.Log d in data.Logs)
            {
                xlSheet.Cells[i, 10] = d.MFO;
                xlSheet.Cells[i, 11] = d.NumbOfCurrency;
                xlSheet.Cells[i, 12] = d.Date.ToString();
                xlSheet.Cells[i, 13] = d.SaleCurrency;
                xlSheet.Cells[i, 14] = d.BuyCurrency;
                i++;
            }
            xlBook.SaveAs(filename);
            xlBook.Close();
            xlApp.Quit();
            ReleaseObject(xlSheet);
            ReleaseObject(xlBook);
            ReleaseObject(xlApp);
        }
    }
}
