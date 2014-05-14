﻿using System;
using System.Diagnostics;
using HtmlAgilityPack;
using JetBrains.Annotations;
using VkApiGenerator.Extensions;
using VkApiGenerator.Utils;

namespace VkApiGenerator.Model
{
    /// <summary>
    /// Информация о методе на сайте Вконтакте
    /// </summary>
    public class VkMethodInfo
    {
        /// <summary>
        /// Описание метода
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Параметры метода
        /// </summary>
        public VkMethodParamsCollection Params { get; set; }

        /// <summary>
        /// Название метода на сервере Вконтакте
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Тип возвращаемого значения
        /// </summary>
        public ReturnType ReturnType { get; set; }

        /// <summary>
        /// Название метода используемого в C# коде
        /// </summary>
        public string CanonicalName
        {
            get
            {
                if (string.IsNullOrEmpty(Name)) return string.Empty;

                int pos = Name.LastIndexOf(".", StringComparison.Ordinal);
                if (pos == -1)
                    return Name.Capitalize();

                return Name.Substring(pos + 1).Capitalize();
            }
        }

        public VkMethodInfo()
        {
            Params = new VkMethodParamsCollection();
        }

        public static VkMethodInfo Parse(HtmlDocument html)
        {
            var info = new VkMethodInfo();

            info.Description = GetDesctiption(html);
            info.Params = GetParams(html);

            return info;
        }

        #region Internal methods
        [NotNull, Pure]
        internal static string GetDesctiption(HtmlDocument html)
        {
            HtmlNode methodDesc = html.DocumentNode.SelectSingleNode("//*[contains(@class, 'dev_method_desc')]");
            Debug.Assert(methodDesc != null);

            string desctiption = HtmlHelper.RemoveHtmlComment(methodDesc.InnerText);
            Debug.WriteLine("  Description: " + desctiption);

            return desctiption;
        }

        [NotNull, Pure]
        internal static VkMethodParamsCollection GetParams(HtmlDocument html)
        {
            if (html == null)
                throw new ArgumentNullException("html");

            var result = new VkMethodParamsCollection();

            HtmlNode paramsSection = html.DocumentNode.SelectSingleNode("(//div[@class='wk_header dev_block_header'])[1]");
            System.Console.WriteLine("Section name: " + paramsSection.InnerText);
            HtmlNode div = paramsSection.ParentNode;
            HtmlNode table = div.SelectSingleNode("table");

            Debug.Assert(table != null);
            System.Console.WriteLine("table is not null");

            HtmlNodeCollection rows = table.SelectNodes("tr");
            foreach (HtmlNode row in rows)
            {   
                HtmlNodeCollection columns = row.SelectNodes("td");
                Debug.Assert(columns.Count == 2);

                var param = new VkMethodParam
                {
                    Name = columns[0].InnerText,
                    Description = HtmlHelper.RemoveHtmlComment(columns[1].InnerText),
                    Restrictions = VkMethodParam.GetRestrictions(columns[1])
                };

                result.Add(param);
            }

            return result;
        }
        #endregion
    }
}