using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestMongoDB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> beispielBtnTexte;
        List<string> beispielTexte;
        List<RoutedEventHandler> beispielClicks;

        Button btnCurrent; //Button aus spLeft nach Druck hier gesetzt

        private static readonly MongoDBexamples mdbEx = new MongoDBexamples();


        public MainWindow()
        {
            InitializeComponent();


            Button btnExecute = (Button)Root.FindName("btnExecute");
            btnExecute.Click += (x,y) => btnCurrent.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));

            Beispiel a = new Beispiel("Beispiel-Objekt 1");
            a.addDescription(
                "string dbConnectionURI = \"mongodb://localhost:27017\";"
                +"\n"+ "var dbClient = new MongoClient(dbConnectionURI);"
            );
            //a.addClickHandler((x,y) => { lbInput.Content = a.description; lbOutput.Content = "Test-Objekt"; btnCurrent = a.getButton(); });
            a.addClickHandler((x, y) => {
                lbInput.Content = a.description;
                Button intern = new Button();
                intern.Click += (x,y) => lbOutput.Content = "ein fast komplett dynamisches Ergebnis";
                btnCurrent = intern;
            });
            spLeft.Children.Add(a.getButton());
            /*
            Beispiel bsp = new Beispiel("Beispiel1", 
                "Ein ganz langer Text der den Inhalt des Buttons beschreibt. " +
                "\n\n tgarergegergeagregsdfgdf", null);


            bsp.description = "" +
                "" +
                "" +
                "" +
                "" +
                "";
            */

            /*
            MongoDBConnector2 mdbc = MongoDBConnector2.getInstance();
            mdbc.getDBClient();
            string s="";
            foreach (var db in mdbc.getDBlist())
            {
                //s += db.GetValue(0) +"\n";
                s += db + "\n";
            }
            lbOutput.Content = s;
            */
            beispielClicks = new List<RoutedEventHandler>();
            beispielClicks.Add(beispiel1);
            //beispielClicks.Add(new RoutedEventHandler(beispiel1));

            beispielBtnTexte = new List<string>();
            beispielTexte = new List<string>();
            beispielBtnTexte.Add("Beispiel1");
            beispielTexte.Add("Beispiel1 Beschreibung");

            /*Button test = new Button();
            test.Content = "Test";
            test.Click += new RoutedEventHandler(beispiel1);
            spLeft.Children.Add(test);
            */

            int beispielAnzahl = 1;
            List<Button> btns = createButtons(beispielAnzahl);
            for (int i = 1; i <= beispielAnzahl; i++) {
                int iTmp = i - 1;
                string tmp = "Beispiel"+iTmp;
                Button m = btns.ElementAt(iTmp);//(Button) Root.FindName(tmp); //new Button(); // 
                m.Content = beispielBtnTexte.ElementAt(iTmp); //"Hallo Welt"; // 
                m.Click += beispielClicks.ElementAt(iTmp);
                spLeft.Children.Add(m);
            }
            /*foreach (Button btn in btns) {
                Root.FindName("Beispiel");
            }*/

            /*
            Button a = new Button();
            a.Content = "Beispiel1";
            a.Click += (Object sender, RoutedEventArgs e) => { lbOutput.Content = "Test"; };
            spLeft.Children.Add(a);
            */

            //MongoClient mc = MongoDBConnector2.createDBClient("mongodb://localhost:27020");
            //MongoDBConnector2.getDBlist(MongoDBConnector2.);
        }

        private List<Button> createButtons(int n) {
            List<Button> btns = new List<Button>();
            for (int i = 1; i <= n; i++) {
                string tmp = "Beispiel" + i;
                Button btTmp = new Button();
                btTmp.Name = tmp;
                btTmp.Content = tmp;
                btns.Add(btTmp);
            }
            return btns;
        }

        private void initBeispielTexte() { 
        
        }
        private void initBeispielBtnTexte(){
            //beispielBtnTexte
        }
        private void initBeispielClicks() {
            beispielClicks = new List<RoutedEventHandler>();
            beispielClicks.Add(beispiel1);
            //beispielClicks.Add(new RoutedEventHandler(beispiel1));
        }

        private void beispiel1(object sender, RoutedEventArgs args) {
            //TODO
            lbInput.Content = "Test";
            lbOutput.Content = "Test";
        }
        private void beispiel2(object sender, RoutedEventArgs args) {
            mdbEx.init();
            lbOutput.Content = "Test";
        }
    }
}
