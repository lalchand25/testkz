﻿@model OLProject.Models.tb_QuizDetail>" 
      <h2>Today`s&nbsp; Report</h2>
   
                    <table id="resultForm:result_table" class="result_table2" width="100%">
<thead>
  <tr>
    <th width="6%"><img src="../../images/s.no.png" width="50" height="50" /></th>
    <th width="17%"><img src="../../images/date_time.png" width="50" height="50" /></th>
    <th width="6%"><img src="../../images/test.png" width="50" height="50" /></th>
    <th width="6%"><img src="../../images/score.png" width="50" height="50" /></th>
    <th width="12%"><img src="../../images/time.png" width="50" height="50" /></th>
    <th width="10%"><img src="../../images/attempt.png" width="50" height="50" /></th>
    <th width="11%"><img src="../../images/subject.png" width="50" height="50" /></th>
    <th width="9%"><img src="../../images/level.png" width="50" height="50" /></th>
    <th width="9%"><img src="../../images/unit.png" width="50" height="50" /></th>
    <th width="8%"><img src="../../images/Status.png" width="50" height="50" /></th>
    <th width="6%"><img src="../../images/view.png" width="50" height="50" /></th>
    
      
  </tr>
  
    <tr>
    <th>S. No.</th>
    <th>Date and Time</th>
    <th>Test ID</th>
    <th>Score</th>
    <th>Time</th>
    <th>Attempt</th>
    <th>Subject</th>
    <th>Level</th>
    <th>Unit</th>
    <th>Status</th>
    <th>View</th>
    
      
  </tr>
  </thead>
  
  <tbody>
        @Html.Raw(ViewData["data"]
        </tbody></table> 

