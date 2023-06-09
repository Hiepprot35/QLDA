﻿using ProjectManager.Teacher.Data;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Teacher.Pages
{
    public class IndexBase : CommonComponentBase
    {
        public int totalProjectList;
        public int totalSuccess;
        public int totalFail;
        public bool isLoading;

        protected override async Task OnInitializedAsync()
        {
            Logout();
            isLoading = true;

            var projectList = await _projectListService.GetAllProjectListAsync(token);
            totalProjectList = projectList.TotalRecords;
            totalSuccess = projectList.Data.Where(x => Convert.ToDecimal(x.Point) >= Convert.ToDecimal("7")).Count();
            totalFail = projectList.Data.Where(x => Convert.ToDecimal(x.Point) < Convert.ToDecimal("7")).Count();

            await Delay();
            isLoading = false;
        }

        public void HandleClick(string url, long value)
        {
            _navigationManager.NavigateTo(url, true);
            projectListStatus = value;
        }
    }
}
