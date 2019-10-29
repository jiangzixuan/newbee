using Newbee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Newbee.Bll
{
    public class QuestionHelper
    {
        private static readonly string QuestionXMLPath = "/App_Data/Questions.xml";

        public static List<M_Question> Questions = null;

        private static object _lock = new object();

        static QuestionHelper()
        {
            if (Questions == null)
            {
                lock (_lock)
                {
                    if (Questions == null)
                        SetQuestionsByXML();
                }
            }
        }

        private static void SetQuestionsByXML()
        {
            List<M_Question> ql = new List<M_Question>();

            XDocument file = XDocument.Load(GetMapPath(QuestionXMLPath));

            // 获取xml文件的根节点
            XElement xmlRoot = file.Root;
            // 获取根节点下的第一级子节点
            IEnumerable<XElement> nodeFirst = xmlRoot.Elements();

            M_Question q = null;
            M_QuesOption qo = null;
            foreach (var item in nodeFirst)
            {
                q = new M_Question();
                q.Num = int.Parse(item.Element("num").Value);
                q.Content = item.Element("content").Value;
                q.Pic = item.Element("pic").Value;
                q.Point = string.IsNullOrEmpty(item.Element("point").Value) ? 0 : int.Parse(item.Element("point").Value);
                q.Options = new List<M_QuesOption>();
                foreach (var node in item.Element("options").Elements())
                {
                    qo = new M_QuesOption();
                    qo.Num = node.Element("num").Value;
                    qo.Content = node.Element("content").Value;
                    qo.Point = int.Parse(node.Element("point").Value);
                    qo.Point = string.IsNullOrEmpty(node.Element("point").Value) ? 0 : int.Parse(node.Element("point").Value);
                    q.Options.Add(qo);
                }
                ql.Add(q);
            }

            Questions = ql;
        }

        /// <summary>
        /// 获取路径
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private static string GetMapPath(string path)
        {
            if (HttpContext.Current != null)
            {
                return HttpContext.Current.Server.MapPath(path);
            }
            else
            {
                return System.Web.Hosting.HostingEnvironment.MapPath(path);
            }
        }
    }
}
