﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject.Areas.Admin.ModelsAdo
{
    public class DataTablesAjaxRequestModelAdo
    {
            
        private HttpRequest _request;

        private int Start
        {
            get
            {
                return int.Parse(_request.Query["start"]);
            }
        }
        public int Length
        {
            get
            {
                return int.Parse(_request.Query["length"]);
            }
        }

        public string SearchText
        {
            get
            {
                return _request.Query["search[value]"];
            }
        }

        public int SortingCols { get; set; }

        public DataTablesAjaxRequestModelAdo(HttpRequest request)
        {
            _request = request;
        }

        public int PageIndex
        {
            get
            {
                if (Length > 0)
                {
                    return (Start / Length) + 1;

                }


                else
                {
                    return 1;
                }
                    
            }
        }

        public int PageSize
        {
            get
            {
                if (Length == 0)
                {
                    return 10;
                }
                    


                else
                {
                    return Length;
                }
                    
            }
        }

        public static object EmptyResult
        {
            get
            {
                return new
                {
                    recordsTotal = 0,
                    recordsFiltered = 0,
                    data = (new string[] { }).ToArray()
                };
            }
        }

        public string GetSortText(string[] columnNames)
        {
            var sortText = new StringBuilder();
            for (var i = 0; i < columnNames.Length; i++)
            {
                if (_request.Query.ContainsKey($"order[{i}][column]"))
                {
                    if (sortText.Length > 0)
                        sortText.Append(",");

                    var column = int.Parse(_request.Query[$"order[{i}][column]"]);
                    var direction = _request.Query[$"order[{i}][dir]"].ToString();
                    var sortDirection = $"{columnNames[column]} {(direction == "asc" ? "asc" : "desc")}";
                    sortText.Append(sortDirection);
                }
            }
            return sortText.ToString();
        }
    }
}

