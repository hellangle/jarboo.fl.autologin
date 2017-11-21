using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using ScrapySharp;
using ScrapySharp.Extensions;

namespace FetLife.AutoLogin.Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            string content = "<form novalidate='novalidate' class='simple_form new_user' id='new_user' action='/users/sign_in' accept-charset='UTF-8' method='post'><input name='utf8' type='hidden' value='✓'><input type='hidden' name='authenticity_token' value='RPJMe0PBSd0hqx1W02zg9G4Pk1Ur/9tGHk4KtZkajNSVidj3sW70d1Ws4gbjty1b81IjZ8ci3+j29gYZKX8IPA=='><div class='pt3 ph3 pb2 bb b--dark-gray'><input value='step_1' type='hidden' name='user[otp_attempt]' id='user_otp_attempt'><input value='en' type='hidden' name='user[locale]' id='user_locale'><label class='db pl1 pb1 f5 lh-copy gray' for='login'>Nickname or Email</label><div class='input w-100 string required user_login'><div><div class='input-group'><input class='form-control string required a-input db w-100 mb3 ba b--black bg-white-30 pa2 f4 lh-copy white-90  ' type='text' autocomplete='off' autocapitalize='off' autocorrect='off' autofocus='autofocus' placeholder='Nickname or Email' name='user[login]' id='user_login'></div></div></div><label class='db pl1 pb1 f5 lh-copy gray' for='password'>Password</label><div class='input w-100 password required user_password'><div><div class='input-group'><input class='form-control password required a-input db w-100 mb3 ba b--black bg-white-30 pa2 f4 lh-copy white-90  ' type='password' autocomplete='off' autocapitalize='off' autocorrect='off' placeholder='Password' name='user[password]' id='user_password'></div></div></div><div class='pt1 mb3 pl1'><input id='remember_me' name='user[remember_me]' type='checkbox'><label class='pl2 silver' for='remember_me'>Remember me, I'll be back.</label></div></div><div class='ph3 pt2 pb3'><button class='db w-100 mt3 mb3 shadow-4 ba b--black pa3 tc link f5 lh-title white bg-dark-secondary hover-bg-secondary pointer' type='submit'>Login to FetLife</button></div></form>";
            string content2 = "<ul id='nav_dropdown' class='horizontal profile'>          <li class='nojs'>            <a href='#' class='small rcts pulldown-trigger'><span class='nickname'>hellangle381</span><span class='or'>&or;</span></a>            <ul class='vertical rcbs'><li class='seperator'>  <a href='/users/8024370'>    <span class='picto'>U</span>    View Your Profile</a>              </li><li>  <a href='/users/8024370/friends'>    <span class='picto'>g</span>    View Your Friends</a>              </li><li class='seperator'>  <a href='/explore/stuff-you-love'>    <span class='picto'>k</span>    Stuff You Love</a>              </li><li class='seperator'>  <a href='/pictures/new'>    <span class='picto'>v</span>    Upload Pictures</a>              </li><li>  <a href='/videos/new'>    <span class='picto'>V</span>    Upload Videos</a>              </li><li>  <a href='/posts/new'>    <span class='picto'>W</span>    Write</a>              </li><li>  <a href='/invite'>    <span class='picto'>J</span>    Invite a Friend    (0)</a>              </li><li class='seperator'>  <a href='/settings/profile'>    <span class='picto'>x</span>    Edit Profile</a>              </li><li>  <a href='/settings/email'>    <span class='picto'>y</span>    Update Settings</a>              </li>  <li class='seperator support'>    <a href='/support?ici=nav--support-fetlife&amp;icn=support-fetlife'>      <span class='picto'>$</span>      Support FetLife!</a>                </li><li class='seperator'>  <a href='/android'>    <span class='picto'>}</span>    Android App</a>              </li><li class='seperator'>  <a href='/help'>    <span class='picto'>?</span>    Help</a>              </li><li class='seperator'>  <a rel='nofollow' data-method='delete' href='/users/sign_out'>    <span class='picto'>Q</span>Log Out</a>              </li>            </ul>          </li>        </ul>";
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(content2);

            //var formNode = document.DocumentNode.CssSelect("#new_user");
            //string encoding = document.DocumentNode.CssSelect("input[name='utf8']").Single().GetAttributeValue("value");
            //string crtf = document.DocumentNode.CssSelect("input[name='authenticity_token']").Single().GetAttributeValue("value");
            //string otp = document.DocumentNode.CssSelect("#user_otp_attempt").Single().GetAttributeValue("value");
            //string locale = document.DocumentNode.CssSelect("#user_locale").Single().GetAttributeValue("value");

            string username = document.DocumentNode.CssSelect("#nav_dropdown span.nickname").Single().InnerText;
            var ulNode = document.DocumentNode.Descendants("ul")
                .Where(x => x.Attributes["id"] != null && x.Attributes["id"].Value == "nav_dropdown")
                .Single();
            var nodes = ulNode.SelectNodes("./li/ul/li/a"); 
            for (int i = 0; i < nodes.Count(); i++)
            {
                var node = nodes.ElementAt(i);
                if (i == 0)
                {
                    var userLink = node.Attributes["href"].Value;
                }
            }

            Console.ReadLine();
        }
    }
}
