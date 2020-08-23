namespace Billing_Automation
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.CompilerServices;

    public class InvoiceInfo
    {
        public string date;
        public string invoice;
        public string loadNmber;
        public string totalAmount;
        public string debtorName;
        public string debtorPostalCode;
        public string username = "awbtransportinc@gmail.com";
        public string password = "U2s0m9an";
        public string invFile;
        public string BOLFile;
        public string RateConfFile;

        public InvoiceInfo(string date1, string invoice1, string loadN, string totalAmount1, string dName, string dCode)
        {
            this.date = date1;
            this.invoice = invoice1;
            this.loadNmber = loadN;
            this.totalAmount = totalAmount1;
            this.debtorName = dName;
            this.debtorPostalCode = dCode;
        }

        public string Display() => 
            ($"Invoice {this.invoice}
Date {this.date}
Load Number {this.loadNmber}
Total Amount {this.totalAmount}
Debtor Name {this.debtorName}
DebtorPostalCode {this.debtorPostalCode}" + $"
Invoice File {this.invFile}
BOL File{this.BOLFile}
Rate Conf File {this.RateConfFile}");

        public Tuple<bool, string> FindFiles(string dir, InvoiceInfo inv)
        {
            Tuple<bool, string> tuple;
            try
            {
                List<string> list = (from x in Directory.GetFiles(dir)
                    where Path.GetFileName(x).ToLower().Contains(inv.loadNmber.ToLower())
                    select x).ToList<string>();
                if (list.Count < 2)
                {
                    tuple = new Tuple<bool, string>(false, "Unable to find files with loadnumber : " + inv.loadNmber);
                }
                else
                {
                    string objA = (from x in list
                        where Path.GetFileName(x).ToLower().Contains("bol")
                        select x).First<string>();
                    if (ReferenceEquals(objA, null))
                    {
                        tuple = new Tuple<bool, string>(false, "BOL file not found");
                    }
                    else
                    {
                        inv.BOLFile = objA;
                        string str2 = (from x in list
                            where Path.GetFileName(x).ToLower().Contains("rate")
                            select x).First<string>();
                        if (ReferenceEquals(str2, null))
                        {
                            tuple = new Tuple<bool, string>(false, "Rate File not found");
                        }
                        else
                        {
                            inv.RateConfFile = str2;
                            tuple = new Tuple<bool, string>(true, "");
                        }
                    }
                }
            }
            catch
            {
                tuple = new Tuple<bool, string>(false, "Error in finding Files");
            }
            return tuple;
        }

        public Tuple<bool, string> ValidateReadedData(string invoiceNo)
        {
            long num;
            Tuple<bool, string> tuple;
            if (!long.TryParse(this.invoice, out num))
            {
                tuple = new Tuple<bool, string>(false, "Unable to Extract Invoice Number");
            }
            else
            {
                DateTime time;
                if (!DateTime.TryParse(this.date, out time))
                {
                    tuple = new Tuple<bool, string>(false, "Unable to Extract Date");
                }
                else if (string.IsNullOrWhiteSpace(this.loadNmber) || this.loadNmber.Equals("Quantity", StringComparison.InvariantCultureIgnoreCase))
                {
                    tuple = new Tuple<bool, string>(false, "Unable to Extract Load Number");
                }
                else
                {
                    float num2;
                    if (!float.TryParse(this.totalAmount, out num2))
                    {
                        tuple = new Tuple<bool, string>(false, "Unable to Extract Total Amount");
                    }
                    else
                    {
                        this.totalAmount = this.totalAmount.Replace(",", "");
                        tuple = new Tuple<bool, string>(true, "");
                    }
                }
            }
            return tuple;
        }

        [Serializable, CompilerGenerated]
        private sealed class <>c
        {
            public static readonly InvoiceInfo.<>c <>9 = new InvoiceInfo.<>c();
            public static Func<string, bool> <>9__13_1;
            public static Func<string, bool> <>9__13_2;

            internal bool <FindFiles>b__13_1(string x) => 
                Path.GetFileName(x).ToLower().Contains("bol");

            internal bool <FindFiles>b__13_2(string x) => 
                Path.GetFileName(x).ToLower().Contains("rate");
        }
    }
}

