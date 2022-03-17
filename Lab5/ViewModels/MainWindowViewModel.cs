using System;
using System.Collections.Generic;
using System.Text;
using System.Reactive;
using ReactiveUI;
using System.IO;
using System.Text.RegularExpressions;

namespace Lab5.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        string input;
        public string Input
        {
            get => input;
            set
            {
                this.RaiseAndSetIfChanged(ref input, value);
                if(Regex != null)
                {
                    FindRegex();
                }
            }
        }

        string result;
        public string Result
        {
            get => result;
            set => this.RaiseAndSetIfChanged(ref result, value);
        }

        string regex;
        public string Regex
        {
            get => regex;
            set
            {
                this.RaiseAndSetIfChanged(ref regex, value);
                FindRegex();
            }
        }

        public void FindRegex()
        {
            string answer = "";

            Regex thisRegex = new Regex(regex);
            var matches = thisRegex.Matches(Input);
            
            foreach (var match in matches)
            {
                answer += $"{match}\n";
            }

            Result = answer;
        }

        public void OpenFile(string path)
        {
            if (File.Exists(path))
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    Input = sr.ReadToEnd();
                }
            }
        }
        public void SaveFile(string path)
        {
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.Write(Result);
            }
        }
    }
}
