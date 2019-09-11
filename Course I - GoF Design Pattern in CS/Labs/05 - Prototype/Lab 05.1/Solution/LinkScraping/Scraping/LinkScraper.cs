﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Scraping
{
    public class LinkScraper : ICloneable
    {
        public string Url { get; }

        public IEnumerable<LinkInfo> AnalysisResult => _analysisResult;
        private List<LinkInfo> _analysisResult;

        #region ICloneable Members

        public object Clone()
        {
            LinkScraper clone = new LinkScraper(Url)
            {
                _analysisResult = _analysisResult
                    .Select(li => li.Clone())
                    .OfType<LinkInfo>()
                    .ToList()
            };

            return clone;
        }

        #endregion

        public LinkScraper( string url )
        {
            Url = url;
        }

        public async Task ScrapeAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                string html = await client.GetStringAsync( Url );

                List<LinkInfo> results = new List<LinkInfo>();

                Regex reg = new Regex(@"href\s*=\s*(?:""(?<1>[^""]*)""|(?<1>\S+))",
                   RegexOptions.IgnoreCase | RegexOptions.Compiled);

                // Convert all href="..." matches by Regex to LinkInfo instances
                for (Match m = reg.Match(html); m.Success; m = m.NextMatch())
                {
                    results.Add(
                        new LinkInfo(
                            m.Groups[1].Index, 
                            m.Groups[1].ToString()
                        )
                    );
                }

                _analysisResult = results;
            }
        }
    }
}