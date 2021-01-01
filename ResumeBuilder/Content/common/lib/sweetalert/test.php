<!doctype html>

<html>
<head>
<meta charset="utf-8">
<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=0" />
<title>SweetAlert</title>
<script src="https://code.jquery.com/jquery-2.1.3.min.js"></script>

<!-- This is what you need -->
<script src="dist/sweetalert-dev.js"></script>
<link rel="stylesheet" href="dist/sweetalert.css">
<!--.......................-->

</head>

<body>

<!-- Examples --> 

<script>
swal({
		title: "Are you sure?",
		text: "Please confirm you option before ok.",
		type: "warning",
		showCancelButton: true,
		confirmButtonColor: '#DD6B55',
		confirmButtonText: 'Yes',
		closeOnConfirm: false
	},
	function(){
		alert('ok pressed');
		swal("Sueess!", "Your employee record changed", "success");
	}); 
 
</script>
</body>
</html>
