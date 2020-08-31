
$(document).ready(function () {
    $('#formCadastro').submit(function (e) {
        e.preventDefault();
        $.ajax({
            url: urlPost,
            method: "POST",
            data: {
                "NOME": $(this).find("#Nome").val(),
                "CEP": $(this).find("#CEP").val(),
                "Email": $(this).find("#Email").val(),
                "Sobrenome": $(this).find("#Sobrenome").val(),
                "Nacionalidade": $(this).find("#Nacionalidade").val(),
                "Estado": $(this).find("#Estado").val(),
                "Cidade": $(this).find("#Cidade").val(),
                "Logradouro": $(this).find("#Logradouro").val(),
				"Telefone": $(this).find("#Telefone").val(),
				"CPF": $(this).find("#CPF").val()
            },
            error:
            function (r) {
                if (r.status == 400)
                    ModalDialog("Ocorreu um erro", r.responseJSON);
                else if (r.status == 500)
                    ModalDialog("Ocorreu um erro", "Ocorreu um erro interno no servidor.");
            },
            success:
            function (r) {
                ModalDialog("Sucesso!", r)
                $("#formCadastro")[0].reset();
            }
        });
    })
	var popup = document.getElementById("popup");
	popup.onclick = function () {
		ModalPopUp()
	}
	$('#incluiBene').on('click', function (e) {
		e.preventDefault();
		$.ajax({
			url: urlPostBene,
			method: "POST",
			data: {
				"NOME": $(this).find("#NomeBene").val(),
				"CPF": $(this).find("#CPFBene").val()
			},
			error:
				function (r) {
					if (r.status == 400)
						ModalDialog("Ocorreu um erro", r.responseJSON);
					else if (r.status == 500)
						ModalDialog("Ocorreu um erro", "Ocorreu um erro interno no servidor.");
				},
			success:
				function (r) {
					ModalDialog("Sucesso!", r)
					$("#formBeneficio")[0].reset();
				}
		});

	});
})

function ModalDialog(titulo, texto) {
    var random = Math.random().toString().replace('.', '');
    var texto = '<div id="' + random + '" class="modal fade">                                                               ' +
        '        <div class="modal-dialog">                                                                                 ' +
        '            <div class="modal-content">                                                                            ' +
        '                <div class="modal-header">                                                                         ' +
        '                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>         ' +
        '                    <h4 class="modal-title">' + titulo + '</h4>                                                    ' +
        '                </div>                                                                                             ' +
        '                <div class="modal-body">                                                                           ' +
        '                    <p>' + texto + '</p>                                                                           ' +
        '                </div>                                                                                             ' +
        '                <div class="modal-footer">                                                                         ' +
        '                    <button type="button" class="btn btn-default" data-dismiss="modal">Fechar</button>             ' +
        '                                                                                                                   ' +
        '                </div>                                                                                             ' +
        '            </div><!-- /.modal-content -->                                                                         ' +
        '  </div><!-- /.modal-dialog -->                                                                                    ' +
        '</div> <!-- /.modal -->                                                                                        ';

    $('body').append(texto);
    $('#' + random).modal('show');
}

function ModalPopUp() {
	var random = Math.random().toString().replace('.', '');
	var texto = '<div id="' + random + '" class="modal fade">                                                               ' +
		'        <div class="modal-dialog">                                                                                 ' +
		'            <div class="modal-content">  ' +
		'                <div class="modal-header">                                                                         ' +
		'                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>         ' +
		'                    <h4 class="modal-title">Beneficiarios</h4>                                                    ' +
		'                </div>                                                                                             ' +
		'                <div class="modal-body">                                                                           ' +
						'<form id="formBeneficiario" method="post">' +
						'<div class="row">' +
						'	<div class="col-sm-5">' +
						'		<div class="form-group">' +
						'			<label for="CPF">CPF:</label>' +
						'			<input required="required" type="text" class="form-control" id="CPFBene" name="CPF" placeholder="Ex.: 010.011.111-00" maxlength="14">' +
						'		</div>' +
						'	</div>' +
					'		<div class="col-sm-5">' +
					'			<div class="form-group">' +
					'				<label for="Nome">Nome:</label>' +
					'				<input required="required" type="text" class="form-control" id="NomeBene" name="Nome" placeholder="Ex.: João" maxlength="50">' +
							'	</div>' +
					'		</div>' +
							'<div class="col-sm-2">' +
								'<div class="pull-right">' +
									'<button type="button" class="btn btn-sm btn-success" id="incluiBene">Incluir</button>' +
								'</div>' +
							'</div > ' +
						'</div>' +
						'</form>' +
	'                </div>                                                                                             ' +
		'                <div class="modal-footer">                                                                         ' +
		'                    <button type="button" class="btn btn-default" data-dismiss="modal">Fechar</button>             ' +
		'                                                                                                                   ' +
		'                </div>                                                                                             ' +
		'            </div><!-- /.modal-content -->                                                                         ' +
		'  </div><!-- /.modal-dialog -->                                                                                    ' +
		'</div> <!-- /.modal -->  '


	$('body').append(texto);
	$('#' + random).modal('show');
}