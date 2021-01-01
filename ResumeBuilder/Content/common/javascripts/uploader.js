function fileSizeformat(fileSize){
	if (fileSize / 1024 > 1){
		if (((fileSize / 1024) / 1024) > 1){
			fileSize = (Math.round(((fileSize / 1024) / 1024) * 100) / 100);
			var actual_fileSize = fileSize + " GB";
		}else{
			fileSize = (Math.round((fileSize / 1024) * 100) / 100)
			var actual_fileSize = fileSize + " MB";
		}
	 }else{
			fileSize = (Math.round(fileSize * 100) / 100)
			var actual_fileSize = fileSize  + " KB";
	}
	return actual_fileSize;
}

function fileIcon(file_to_add){

if( file_to_add == "3gp"){ file_icon = '<img src="images/3gp.png" align="absmiddle" border="0" alt="" />'; }
else if( file_to_add == "ai"){ file_icon = '<img src="images/ai.png" align="absmiddle" border="0" alt="" />';  }
else if( file_to_add == "asp"){ file_icon = '<img src="images/asp.png" align="absmiddle" border="0" alt="" />'; }
else if( file_to_add == "avi"){ file_icon = '<img src="images/avi.png" align="absmiddle" border="0" alt="" />'; }
else if( file_to_add == "bin"){ file_icon = '<img src="images/bin.png" align="absmiddle" border="0" alt="" />'; }
else if( file_to_add == "bmp"){ file_icon = '<img src="images/bmp.png" align="absmiddle" border="0" alt="" />'; }
else if( file_to_add == "cpp"){ file_icon = '<img src="images/cpp.png" align="absmiddle" border="0" alt="" />'; }
else if( file_to_add == "css"){ file_icon = '<img src="images/css.png" align="absmiddle" border="0" alt="" />'; }
else if( file_to_add == "dll" ){ file_icon = '<img src="images/dll.png" align="absmiddle" border="0" alt="" />'; }
else if( file_to_add == "doc" || file_to_add == "docx" || file_to_add == "rtf" ){ file_icon = '<img src="images/doc.png" align="absmiddle" border="0" alt="" />'; }
else if( file_to_add == "exe" ){ file_icon = '<img src="images/exe.png" align="absmiddle" border="0" alt="" />'; }
else if( file_to_add == "flv" ){ file_icon = '<img src="images/flv.png" align="absmiddle" border="0" alt="" />'; }
else if( file_to_add == "gif" ){ file_icon = '<img src="images/gif.png" align="absmiddle" border="0" alt="" />'; }
else if( file_to_add == "htm" || file_to_add == "html" ){ file_icon = '<img src="images/htm.png" align="absmiddle" border="0" alt="" />'; }
else if( file_to_add == "java" ){ file_icon = '<img src="images/java.png" align="absmiddle" border="0" alt="" />'; }
else if( file_to_add == "jpg" || file_to_add == "jpeg" ){ file_icon = '<img src="images/jpg.png" align="absmiddle" border="0" alt="" />'; }
else if( file_to_add == "js" ){ file_icon = '<img src="images/js.png" align="absmiddle" border="0" alt="" />'; }
else if( file_to_add == "mdb" ){ file_icon = '<img src="images/mdb.png" align="absmiddle" border="0" alt="" />'; }
else if( file_to_add == "mp3" ){ file_icon = '<img src="images/mp3.png" align="absmiddle" border="0" alt="" />'; }
else if( file_to_add == "mp4" ){ file_icon = '<img src="images/mp4.png" align="absmiddle" border="0" alt="" />'; }
else if( file_to_add == "mpg" ){ file_icon = '<img src="images/mpg.png" align="absmiddle" border="0" alt="" />'; }
else if( file_to_add == "msi" ){ file_icon = '<img src="images/msi.png" align="absmiddle" border="0" alt="" />'; }
else if( file_to_add == "pdf" ){ file_icon = '<img src="images/pdf.png" align="absmiddle" border="0" alt="" />'; }
else if( file_to_add == "php" ){ file_icon = '<img src="images/php.png" align="absmiddle" border="0" alt="" />'; }
else if( file_to_add == "png" ){ file_icon = '<img src="images/png.png" align="absmiddle" border="0" alt="" />'; }
else if( file_to_add == "pps" ){ file_icon = '<img src="images/pps.png" align="absmiddle" border="0" alt="" />'; }
else if( file_to_add == "ppt" || file_to_add == "pptx" ){ file_icon = '<img src="images/ppt.png" align="absmiddle" border="0" alt="" />'; }
else if( file_to_add == "ps" ){ file_icon = '<img src="images/ps.png" align="absmiddle" border="0" alt="" />'; }
else if( file_to_add == "psd" ){ file_icon = '<img src="images/psd.png" align="absmiddle" border="0" alt="" />'; }
else if( file_to_add == "rar" ){ file_icon = '<img src="images/rar.png" align="absmiddle" border="0" alt="" />'; }
else if( file_to_add == "svg" ){ file_icon = '<img src="images/svg.png" align="absmiddle" border="0" alt="" />'; }
else if( file_to_add == "swf" ){ file_icon = '<img src="images/swf.png" align="absmiddle" border="0" alt="" />'; }
else if( file_to_add == "tif" ){ file_icon = '<img src="images/tif.png" align="absmiddle" border="0" alt="" />'; }
else if( file_to_add == "tmp" ){ file_icon = '<img src="images/tmp.png" align="absmiddle" border="0" alt="" />'; }
else if( file_to_add == "txt" ){ file_icon = '<img src="images/txt.png" align="absmiddle" border="0" alt="" />'; }
else if( file_to_add == "vcd" ){ file_icon = '<img src="images/vcd.png" align="absmiddle" border="0" alt="" />'; }
else if( file_to_add == "wma" ){ file_icon = '<img src="images/wma.png" align="absmiddle" border="0" alt="" />'; }
else if( file_to_add == "wmv" ){ file_icon = '<img src="images/wmv.png" align="absmiddle" border="0" alt="" />'; }
else if( file_to_add == "xls" || file_to_add == "xlsx"  ){ file_icon = '<img src="images/xls.png" align="absmiddle" border="0" alt="" />'; }
else if( file_to_add == "xml" ){ file_icon = '<img src="images/xml.png" align="absmiddle" border="0" alt="" />'; }
else if( file_to_add == "zip" ){ file_icon = '<img src="images/zip.png" align="absmiddle" border="0" alt="" />'; }
else {  file_icon = '<img src="images/unknown.png" align="absmiddle" border="0" alt="" />'; }


return file_icon;

}

function file_ext(file) {
	return (/[.]/.exec(file)) ? /[^.]+$/.exec(file.toLowerCase()) : '';
}

function remove_this_file(id, filename)
{
	if(confirm('Are you sure to remove this file?'))	{
		$("#removed_files").append('<input type="hidden" id="'+id+'" value="'+id+'">');
		$("#add_fileID"+id).hide();
	
		
	}
	return false;
}

function multiple_file_uploader(configuration_settings)
{
	this.settings = configuration_settings;
	this.files = "";
	this.browsed_files = []
	var self = this;
	var msg = "Browser does not support!";
	
	multiple_file_uploader.prototype.show_added_files = function(value)
	{
		this.files = value;
		if(this.files.length > 0)
		{
			var added_files_displayer = file_id = "";
 			for(var i = 0; i<this.files.length; i++)
			{
				var files_name_without_extensions = this.files[i].name.substr(0, this.files[i].name.lastIndexOf('.')) || this.files[i].name;
				file_id = files_name_without_extensions.replace(/[^a-z0-9\s]/gi, '').replace(/[_\s]/g, '');
				
				var file_to_add = file_ext(this.files[i].name);		
				var fileSize = (this.files[i].size / 1024);
				var file_icon;

				if(typeof this.files[i] != undefined && this.files[i].name != ""){
					added_files_displayer += '<div id="add_fileID'+file_id+'" class="bx_main"> <div class="bx_1">'+fileIcon(file_to_add)+'</div> <div class="bx_2"><span class="fname">'+this.files[i].name.substring(0, 30)+'</span> <br/> <span class="fsize">'+fileSizeformat(fileSize)+'</span>  </div><div class="bx_3" id="bx_3_'+file_id+'"> <a htef="#null" onclick="remove_this_file(\''+file_id+'\',\''+this.files[i].name+'\');"> <img border="0" src="images/ico_cancel.png" width="16" height="15"> </div> </div>';
				}
			}
			$(".file_boxes").html("");
			$("#removed_files").html("");
			$(".file_boxes").append(added_files_displayer);
		}
	}
	
	//File Reader
	multiple_file_uploader.prototype.read_file = function(e) {
		if(e.target.files) {
			self.show_added_files(e.target.files);
			self.browsed_files.push(e.target.files);
		} else {
			alert('Sorry, a file you have specified could not be read at the moment. Thank You!');
		}
	}
	
	
	function addEvent(type, el, fn){
	if (window.addEventListener){
		el.addEventListener(type, fn, false);
	} else if (window.attachEvent){
		var f = function(){
		  fn.call(el, window.event);
		};			
		el.attachEvent('on' + type, f)
	}
}

	
	//Get the ids of all added files and also start the upload when called
	multiple_file_uploader.prototype.starter = function() {
		if (window.File && window.FileReader && window.FileList && window.Blob) {		
			 var browsed_file_ids = $("."+this.settings.div_class).find("input[type='file']").eq(0).attr("id");
			 document.getElementById(browsed_file_ids).addEventListener("change", this.read_file, false);
		} 
		else { alert(msg); }
	}
	
	//Call the uploading function when click on the upload button
	multiple_file_uploader.prototype.submit_added_files = function(){ self.upload_bgin(); }
	
	//Start uploads
	multiple_file_uploader.prototype.upload_bgin = function() {
		if(this.browsed_files.length > 0) {
			for(var k=0; k<this.browsed_files.length; k++){
				var file = this.browsed_files[k];
				this.uplodMulty(file,k);
			}
		}
	}
	
	
	//Main file uploader
	multiple_file_uploader.prototype.uplodMulty = function(file,file_counter)
	{
	
	if( file[file_counter] !=undefined || file[file_counter] !='' || file[file_counter] !="undefined" )
		{
		
		if(file[file_counter]!=undefined ){
			//Use the file names without their extensions as their ids
			var files_name_without_extensions = file[file_counter].name.substr(0, file[file_counter].name.lastIndexOf('.')) || file[file_counter].name;
			var ids = files_name_without_extensions.replace(/[^a-z0-9\s]/gi, '').replace(/[_\s]/g, '');
			var browsed_file_ids = $("#"+this.settings.div_class).find("input[type='file']").eq(0).attr("id");
			
			var removed_file = $("#"+ids).val();
			
			if ( removed_file != "" && removed_file != undefined && removed_file == ids )
			{
				this.uplodMulty(file,file_counter+1);
				
			}
			else
			{
				var dataString = new FormData();
				dataString.append('upload_file',file[file_counter]);
				dataString.append('upload_file_ids',ids);
					
				$.ajax({
					type:"POST",
					url:this.settings.server_url,
					data:dataString,
					cache: false,
					contentType: false,
					processData: false,
					beforeSend: function() 
					{
						$("#bx_3_"+ids).html('<img src="images/loader.gif" width="16" height="16" align="absmiddle" title="File Uploading"/>');
					},
					success:function(response) 
					{
						setTimeout(function() {
							var response_brought = response.indexOf(ids);
							if ( response_brought != -1) {
								$("#bx_3_"+ids).html('<img src="images/ico_ok.png" width="16" height="16" align="absmiddle" title="Upload Completed"/>');
							} else {
								var fileType_response_brought = response.indexOf('file_type_error');
								if ( fileType_response_brought != -1) {
									
									var filenamewithoutextension = response.replace('file_type_error&', '').substr(0, response.replace('file_type_error&', '').lastIndexOf('.')) || response.replace('file_type_error&', '');
									var fileID = filenamewithoutextension.replace(/[^a-z0-9\s]/gi, '').replace(/[_\s]/g, '');
									$("#bx_3_"+fileID).html('<img src="images/cancel.png" width="16" height="16" align="absmiddle" title="Invalid File"/>');
									
								} else {
									var filesize_response_brought = response.indexOf('file_size_error');
									if ( filesize_response_brought != -1) {
										var filenamewithoutextensions = response.replace('file_size_error&', '').substr(0, response.replace('file_size_error&', '').lastIndexOf('.')) || response.replace('file_size_error&', '');
										var fileID = filenamewithoutextensions.replace(/[^a-z0-9\s]/gi, '').replace(/[_\s]/g, '');
										$("#bx_3_"+fileID).html('<img src="images/cancel.png" width="16" height="16" align="absmiddle" title="Exceeded Size"/>');
									} else {
										var general_response_brought = response.indexOf('general_system_error');
										if ( general_response_brought != -1) {
											alert('Sorry, a file was not uploaded...');
										}
										else { /* Do nothing */}
									}
								}
							}
							if (file_counter+1 < file.length ) {
								self.uplodMulty(file,file_counter+1); 
							} 
							else {}
						},2000);
					}
				});
			 }
		} 
		
	}else { alert('Sorry, ERROR Uploading File!'); }
	
	}	
	this.starter();
}


function remove_this_file1(id, filename)
{
	if(confirm('Are you sure to remove this file?'))	{
		$("#removed_files1").append('<input type="hidden" id="'+id+'" value="'+id+'">');
		$("#add_fileID1"+id).hide();
	
		
	}
	return false;
}

function multiple_file_uploader1(configuration_settings)
{
	this.settings = configuration_settings;
	this.files = "";
	this.browsed_files = []
	var self = this;
	var msg = "Browser does not support!";
	
	multiple_file_uploader1.prototype.show_added_files = function(value)
	{
		this.files = value;
		if(this.files.length > 0)
		{
			var added_files_displayer = file_id = "";
 			for(var i = 0; i<this.files.length; i++)
			{
				var files_name_without_extensions = this.files[i].name.substr(0, this.files[i].name.lastIndexOf('.')) || this.files[i].name;
				file_id = files_name_without_extensions.replace(/[^a-z0-9\s]/gi, '').replace(/[_\s]/g, '');
				
				var file_to_add = file_ext(this.files[i].name);		
				var fileSize = (this.files[i].size / 1024);
				var file_icon;

				if(typeof this.files[i] != undefined && this.files[i].name != ""){
					added_files_displayer += '<div id="add_fileID1'+file_id+'" class="bx_main1"> <div class="bx_11">'+fileIcon(file_to_add)+'</div> <div class="bx_21"><span class="fname1">'+this.files[i].name.substring(0, 30)+'</span> <br/> <span class="fsize1">'+fileSizeformat(fileSize)+'</span>  </div><div class="bx_31" id="bx_31_'+file_id+'"> <a htef="#null" onclick="remove_this_file1(\''+file_id+'\',\''+this.files[i].name+'\');"> <img border="0" src="images/ico_cancel.png" width="16" height="15"> </div> </div>';
				}
			}
			$(".file_boxes1").html("");
			$("#removed_files1").html("");
			$(".file_boxes1").append(added_files_displayer);
		}
	}
	
	//File Reader
	multiple_file_uploader1.prototype.read_file = function(e) {
		if(e.target.files) {
			self.show_added_files(e.target.files);
			self.browsed_files.push(e.target.files);
		} else {
			alert('Sorry, a file you have specified could not be read at the moment. Thank You!');
		}
	}
	
	
	function addEvent(type, el, fn){
	if (window.addEventListener){
		el.addEventListener(type, fn, false);
	} else if (window.attachEvent){
		var f = function(){
		  fn.call(el, window.event);
		};			
		el.attachEvent('on' + type, f)
	}
}

	
	//Get the ids of all added files and also start the upload when called
	multiple_file_uploader1.prototype.starter = function() {
		if (window.File && window.FileReader && window.FileList && window.Blob) {		
			 var browsed_file_ids = $("."+this.settings.div_class).find("input[type='file']").eq(0).attr("id");
			 document.getElementById(browsed_file_ids).addEventListener("change", this.read_file, false);
		} 
		else { alert(msg); }
	}
	
	//Call the uploading function when click on the upload button
	multiple_file_uploader1.prototype.submit_added_files = function(){ self.upload_bgin(); }
	
	//Start uploads
	multiple_file_uploader1.prototype.upload_bgin = function() {
		if(this.browsed_files.length > 0) {
			for(var k=0; k<this.browsed_files.length; k++){
				var file = this.browsed_files[k];
				this.uplodMulty(file,k);
			}
		}
	}
	
	
	//Main file uploader
	multiple_file_uploader1.prototype.uplodMulty = function(file,file_counter)
	{
	
	if( file[file_counter] !=undefined || file[file_counter] !='' || file[file_counter] !="undefined" )
		{
		
		if(file[file_counter]!=undefined ){
			//Use the file names without their extensions as their ids
			var files_name_without_extensions = file[file_counter].name.substr(0, file[file_counter].name.lastIndexOf('.')) || file[file_counter].name;
			var ids = files_name_without_extensions.replace(/[^a-z0-9\s]/gi, '').replace(/[_\s]/g, '');
			var browsed_file_ids = $("#"+this.settings.div_class).find("input[type='file']").eq(0).attr("id");
			
			var removed_file = $("#"+ids).val();
			
			if ( removed_file != "" && removed_file != undefined && removed_file == ids )
			{
				this.uplodMulty(file,file_counter+1);
				
			}
			else
			{
				var dataString = new FormData();
				dataString.append('upload_file',file[file_counter]);
				dataString.append('upload_file_ids',ids);
					
				$.ajax({
					type:"POST",
					url:this.settings.server_url,
					data:dataString,
					cache: false,
					contentType: false,
					processData: false,
					beforeSend: function() 
					{
						$("#bx_31_"+ids).html('<img src="images/loader.gif" width="16" height="16" align="absmiddle" title="File Uploading"/>');
					},
					success:function(response) 
					{
						setTimeout(function() {
							var response_brought = response.indexOf(ids);
							if ( response_brought != -1) {
								$("#bx_31_"+ids).html('<img src="images/ico_ok.png" width="16" height="16" align="absmiddle" title="Upload Completed"/>');
							} else {
								var fileType_response_brought = response.indexOf('file_type_error');
								if ( fileType_response_brought != -1) {
									
									var filenamewithoutextension = response.replace('file_type_error&', '').substr(0, response.replace('file_type_error&', '').lastIndexOf('.')) || response.replace('file_type_error&', '');
									var fileID = filenamewithoutextension.replace(/[^a-z0-9\s]/gi, '').replace(/[_\s]/g, '');
									$("#bx_31_"+fileID).html('<img src="images/cancel.png" width="16" height="16" align="absmiddle" title="Invalid File"/>');
									
								} else {
									var filesize_response_brought = response.indexOf('file_size_error');
									if ( filesize_response_brought != -1) {
										var filenamewithoutextensions = response.replace('file_size_error&', '').substr(0, response.replace('file_size_error&', '').lastIndexOf('.')) || response.replace('file_size_error&', '');
										var fileID = filenamewithoutextensions.replace(/[^a-z0-9\s]/gi, '').replace(/[_\s]/g, '');
										$("#bx_31_"+fileID).html('<img src="images/cancel.png" width="16" height="16" align="absmiddle" title="Exceeded Size"/>');
									} else {
										var general_response_brought = response.indexOf('general_system_error');
										if ( general_response_brought != -1) {
											alert('Sorry, a file was not uploaded...');
										}
										else { /* Do nothing */}
									}
								}
							}
							if (file_counter+1 < file.length ) {
								self.uplodMulty(file,file_counter+1); 
							} 
							else {}
						},2000);
					}
				});
			 }
		} 
		
	}else { alert('Sorry, ERROR Uploading File!'); }
	
	}	
	this.starter();
}

function remove_this_file2(id, filename)
{
	if(confirm('Are you sure to remove this file?'))	{
		$("#removed_files2").append('<input type="hidden" id="'+id+'" value="'+id+'">');
		$("#add_fileID2"+id).hide();
	
		
	}
	return false;
}

function multiple_file_uploader2(configuration_settings)
{
	this.settings = configuration_settings;
	this.files = "";
	this.browsed_files = []
	var self = this;
	var msg = "Browser does not support!";
	
	multiple_file_uploader2.prototype.show_added_files = function(value)
	{
		this.files = value;
		if(this.files.length > 0)
		{
			var added_files_displayer = file_id = "";
 			for(var i = 0; i<this.files.length; i++)
			{
				var files_name_without_extensions = this.files[i].name.substr(0, this.files[i].name.lastIndexOf('.')) || this.files[i].name;
				file_id = files_name_without_extensions.replace(/[^a-z0-9\s]/gi, '').replace(/[_\s]/g, '');
				
				var file_to_add = file_ext(this.files[i].name);		
				var fileSize = (this.files[i].size / 1024);
				var file_icon;

				if(typeof this.files[i] != undefined && this.files[i].name != ""){
					added_files_displayer += '<div id="add_fileID2'+file_id+'" class="bx_main2"> <div class="bx_12">'+fileIcon(file_to_add)+'</div> <div class="bx_22"><span class="fname2">'+this.files[i].name.substring(0, 30)+'</span> <br/> <span class="fsize2">'+fileSizeformat(fileSize)+'</span>  </div><div class="bx_32" id="bx_32_'+file_id+'"> <a htef="#null" onclick="remove_this_file2(\''+file_id+'\',\''+this.files[i].name+'\');"> <img border="0" src="images/ico_cancel.png" width="16" height="15"> </div> </div>';
				}
			}
			$(".file_boxes2").html("");
			$("#removed_files2").html("");
			$(".file_boxes2").append(added_files_displayer);
		}
	}
	
	//File Reader
	multiple_file_uploader2.prototype.read_file = function(e) {
		if(e.target.files) {
			self.show_added_files(e.target.files);
			self.browsed_files.push(e.target.files);
		} else {
			alert('Sorry, a file you have specified could not be read at the moment. Thank You!');
		}
	}
	
	
	function addEvent(type, el, fn){
	if (window.addEventListener){
		el.addEventListener(type, fn, false);
	} else if (window.attachEvent){
		var f = function(){
		  fn.call(el, window.event);
		};			
		el.attachEvent('on' + type, f)
	}
}

	
	//Get the ids of all added files and also start the upload when called
	multiple_file_uploader2.prototype.starter = function() {
		if (window.File && window.FileReader && window.FileList && window.Blob) {		
			 var browsed_file_ids = $("."+this.settings.div_class).find("input[type='file']").eq(0).attr("id");
			 document.getElementById(browsed_file_ids).addEventListener("change", this.read_file, false);
		} 
		else { alert(msg); }
	}
	
	//Call the uploading function when click on the upload button
	multiple_file_uploader2.prototype.submit_added_files = function(){ self.upload_bgin(); }
	
	//Start uploads
	multiple_file_uploader2.prototype.upload_bgin = function() {
		if(this.browsed_files.length > 0) {
			for(var k=0; k<this.browsed_files.length; k++){
				var file = this.browsed_files[k];
				this.uplodMulty(file,k);
			}
		}
	}
	
	
	//Main file uploader
	multiple_file_uploader2.prototype.uplodMulty = function(file,file_counter)
	{
	
	if( file[file_counter] !=undefined || file[file_counter] !='' || file[file_counter] !="undefined" )
		{
		
		if(file[file_counter]!=undefined ){
			//Use the file names without their extensions as their ids
			var files_name_without_extensions = file[file_counter].name.substr(0, file[file_counter].name.lastIndexOf('.')) || file[file_counter].name;
			var ids = files_name_without_extensions.replace(/[^a-z0-9\s]/gi, '').replace(/[_\s]/g, '');
			var browsed_file_ids = $("#"+this.settings.div_class).find("input[type='file']").eq(0).attr("id");
			
			var removed_file = $("#"+ids).val();
			
			if ( removed_file != "" && removed_file != undefined && removed_file == ids )
			{
				this.uplodMulty(file,file_counter+1);
				
			}
			else
			{
				var dataString = new FormData();
				dataString.append('upload_file',file[file_counter]);
				dataString.append('upload_file_ids',ids);
					
				$.ajax({
					type:"POST",
					url:this.settings.server_url,
					data:dataString,
					cache: false,
					contentType: false,
					processData: false,
					beforeSend: function() 
					{
						$("#bx_32_"+ids).html('<img src="images/loader.gif" width="16" height="16" align="absmiddle" title="File Uploading"/>');
					},
					success:function(response) 
					{
						setTimeout(function() {
							var response_brought = response.indexOf(ids);
							if ( response_brought != -1) {
								$("#bx_32_"+ids).html('<img src="images/ico_ok.png" width="16" height="16" align="absmiddle" title="Upload Completed"/>');
							} else {
								var fileType_response_brought = response.indexOf('file_type_error');
								if ( fileType_response_brought != -1) {
									
									var filenamewithoutextension = response.replace('file_type_error&', '').substr(0, response.replace('file_type_error&', '').lastIndexOf('.')) || response.replace('file_type_error&', '');
									var fileID = filenamewithoutextension.replace(/[^a-z0-9\s]/gi, '').replace(/[_\s]/g, '');
									$("#bx_32_"+fileID).html('<img src="images/cancel.png" width="16" height="16" align="absmiddle" title="Invalid File"/>');
									
								} else {
									var filesize_response_brought = response.indexOf('file_size_error');
									if ( filesize_response_brought != -1) {
										var filenamewithoutextensions = response.replace('file_size_error&', '').substr(0, response.replace('file_size_error&', '').lastIndexOf('.')) || response.replace('file_size_error&', '');
										var fileID = filenamewithoutextensions.replace(/[^a-z0-9\s]/gi, '').replace(/[_\s]/g, '');
										$("#bx_32_"+fileID).html('<img src="images/cancel.png" width="16" height="16" align="absmiddle" title="Exceeded Size"/>');
									} else {
										var general_response_brought = response.indexOf('general_system_error');
										if ( general_response_brought != -1) {
											alert('Sorry, a file was not uploaded...');
										}
										else { /* Do nothing */}
									}
								}
							}
							if (file_counter+1 < file.length ) {
								self.uplodMulty(file,file_counter+1); 
							} 
							else {}
						},2000);
					}
				});
			 }
		} 
		
	}else { alert('Sorry, ERROR Uploading File!'); }
	
	}	
	this.starter();
}