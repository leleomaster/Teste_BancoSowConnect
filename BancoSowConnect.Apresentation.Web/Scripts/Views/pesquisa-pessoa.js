$(function ()
{
    varificaDocumentoEhCPF(Boolean(GetValorHiddenEhCpf()));
    addEvents();
});

var GetValorHiddenEhCpf = function ()
{
    var ehCPF = Boolean($("#hiddenEhCpf").val());

    return ehCPF;
};

var addEvents = function ()
{
    $("#radioButtonCPF").on("click", function ()
    {
        $("#hiddenEhCpf").val("True");
        varificaDocumentoEhCPF(true);
        carregarMaskCPF();
    });

    $("#radioButtonCPNJ").on("click", function ()
    {
        $("#hiddenEhCpf").val("False");
        varificaDocumentoEhCPF(false);
        carregarMaskCNPJ();
    });
};

var varificaDocumentoEhCPF = function (ehCPF)
{
    if (ehCPF === true)
    {
        exibirDocumento("cnpj", "cpf", "CPF", true, false);
    }
    else
    {
        exibirDocumento("cpf", "cnpj", "CNPJ", false, true);
    }
};

var exibirDocumento = function (removeClassDocumento, addClassDocumento, textoLabelDocumentoPessoa, ehParaCkecarRadioButtonCPF, ehParaCkecarRadioButtonCNPJ)
{
    let inputDocumento = $("#idDocumentoPessoa");
    inputDocumento.val("");
    inputDocumento.removeClass(removeClassDocumento);
    inputDocumento.addClass(addClassDocumento);

    let labelDocumentoPessoa = $("#labelDocumentoPessoa");
    labelDocumentoPessoa.text(textoLabelDocumentoPessoa);

    $("#radioButtonCPF").prop("checked", ehParaCkecarRadioButtonCPF);
    $("#radioButtonCPNJ").prop("checked", ehParaCkecarRadioButtonCNPJ);
};