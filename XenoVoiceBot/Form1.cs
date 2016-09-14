using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Diagnostics;
using System.IO.Ports;
using System.Xml;
using System.Net;

namespace XenoVoiceBot
{
    public partial class Form1 : Form
    {
        //Dekleracija
        SpeechRecognitionEngine rec = new SpeechRecognitionEngine();
        SpeechSynthesizer s = new SpeechSynthesizer();
        Boolean wake = true;
        Boolean sleep = true;
        Choices list = new Choices();
        public Form1()
        {
            list.Add(new String[] { "hey", "how are you","time","date time",
                "open google","wake up","sleep","open navigation","what is sense of life",
                "open visual studio","exit","search for global news","check my email","open youtube","open facebook","check my upwork"});
            //Jokes
            String[] joke = new string[4] { "A man walks into a library and asks, can I have a cheeseburger the librarian says, sir, this is a library. The man whispers, can I have a cheeseburger?", 
                " how do you catch a runaway laptop? With an internet.", "what did the zero say to the eight? nice belt.", "time flies like an arrow. fruit flies like a banana." };
          ///////// //random jokes
            Grammar gr = new Grammar(new GrammarBuilder(list));
            try
            {
                rec.RequestRecognizerUpdate();
                rec.LoadGrammar(gr);
                rec.SpeechRecognized += rec_SpeechRecognized;
                rec.SetInputToDefaultAudioDevice();
                rec.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch {  }
            {
                s.SelectVoiceByHints(VoiceGender.Female,VoiceAge.Teen);
               
                InitializeComponent();
            }
        }
        public void say(String h)
        {
            s.Speak(h);
        }
        //Pitanja i odgovori
        private void rec_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            String r = e.Result.Text;
            //sta ja kazem
            if (r== "wake up")wake=true;   //Budno stanje
            if (r=="sleep")wake=false;       //Stanje spavanja
            if (sleep = true) label3.Text = "Sleep"; //label text sleep
            if (wake==true)
            {
                label3.Text = "Wake";                  //label text wake
            if (r == "hey")
            {   
               say("hello sir,how are you today?");
                //say(list);
            }
            if (r == "how are you")
            {
                list.Add("great and you");
                say("great and you?");
                //say(list);
            }
            if (r == "time")
            {
                //sati
                say(DateTime.Now.ToString(" hh:mm tt "));
            }
             if (r == "date time")
            {
                 //godina
                say(DateTime.Now.ToString(" M/d/yyyy "));
            }
             if (r=="open google")
             {
                 say("opening google");
                 Process.Start("http://google.com");
             }
             if (r == "open navigation")
             {
                 say("opening navigation");
                 Process.Start("https://www.google.rs/maps?source=tldso");   
             }
             if (r=="what is sense of life")
             {
                 say("sense of life is love and money");
             }
             if (r == "open visual studio")
             {
                 say("opening viusal studio");
                 Process.Start(@"C:/Program Files (x86)/Microsoft Visual Studio 12.0/Common7/IDE/devenv.exe");
             }
             if (r=="exit")
             {
                 say("application will close");
                 this.Close();
             }
             if (r=="search for global news")
             {
                 say("searching for global news");
                 Process.Start("https://www.google.rs/search?q=global+news&oq=global+news&aqs=chrome..69i57j0l5.3574j0j4&sourceid=chrome&ie=UTF-8");
             }
             if (r == "check my email")
             {
                 say("checking mail for you");
                 Process.Start("https://login.live.com/login.srf?wa=wsignin1.0&rpsnv=13&ct=1471374712&rver=6.4.6456.0&wp=MBI_SSL_SHARED&wreply=https:%2F%2Fmail.live.com%2Fdefault.aspx&lc=1033&id=64855&mkt=en-us&cbcxt=mai");
             
             }
             if (r=="open youtube")
             {
                 say("opening yotube for you");
                 Process.Start("http://www.youtube.com");
             }
             if (r=="open facebook")
             {
                 say("opening facebook for you");
                 Process.Start("http://facebook.com");
             }
             if (r=="check my upwork")
             {
                 say("checking upwork for you");
                 Process.Start("https://www.upwork.com/");
             }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label6.Text = DateTime.Now.ToString(" hh:mm tt ");
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.facebook.com");
        }

        private void insta_btn_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.instagram.com");
        }

        private void youtube_btn_Click(object sender, EventArgs e)
        {
            Process.Start("http://youtube.com");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.google.com/gmail/about/");
        }

        private void button3_Click(object sender, EventArgs e)
        {
           // Process.Start(@"C:/Programming,gotove App");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Process.Start(@"C:/Users/Zyzz/Downloads");
        }
    }
}
