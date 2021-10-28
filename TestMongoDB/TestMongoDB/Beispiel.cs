using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace TestMongoDB
{
    class Beispiel
    {
        public RoutedEventHandler clickHandler;
        public string btnContent;
        public string description;
        private static string defaultBtnContent = "Beispiel";
        private static string defaultDescription = "Beschreibung ausstehend";
        private static RoutedEventHandler defaultBtnClickHandler = (x, y) => MessageBox.Show("To be implemented"); // new RoutedEventHandler(defaultClickHandler);

        public Beispiel() : this(defaultBtnContent, defaultDescription, defaultBtnClickHandler) { }
        public Beispiel(string btnContent) : this(btnContent, defaultDescription, defaultBtnClickHandler) {}
        public Beispiel(string btnContent, string description) : this(btnContent, description, defaultBtnClickHandler) {}
        public Beispiel(string btnContent, RoutedEventHandler clickHandler) : this(btnContent, defaultDescription, clickHandler) {}
        public Beispiel(RoutedEventHandler clickHandler) : this(defaultBtnContent, defaultDescription, clickHandler) {}
        public Beispiel(string btnContent, string description, RoutedEventHandler clickHandler) {
            this.description = description;
            this.btnContent = btnContent;
            this.clickHandler = clickHandler;
        }

        public void addDescription(string description) {
            this.description = description;
        }

        public void addClickHandler(RoutedEventHandler clickHandler) {
            this.clickHandler = clickHandler;
        }

        public Button getButton() {
            Button tmp = new Button();
            tmp.Content = btnContent;
            tmp.Click += clickHandler;
            return tmp;
        }

        /*private static void defaultClickHandler(Object sender, RoutedEventArgs args) {
            MessageBox.Show("To be implemented");
        }*/
    }
}
