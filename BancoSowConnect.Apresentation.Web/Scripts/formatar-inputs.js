﻿$(function ()
{
    $('.data').mask('00/00/0000', { placeholder: "__/__/____" });
    $('.numero_conta').mask('9999.9999.9999.9999', { placeholder: "9999.9999.9999.9999" });
    $('.numero_4_digito').mask('9999');
    $('.numero_5_digito').mask('99999');
    $('.numero_6_digito').mask('999999');
    $('.numero_7_digito').mask('9999999');
    $('.numero_8_digito').mask('99999999');
    $('.numero_9_digito').mask('999999999');
    $('.numero_10_digito').mask('9999999999');
    $('.numero_14_digito').mask('99999999999999');
    $('.hora').mask('00:00:00', { placeholder: "00:00:00" });
    $('.data_hora').mask('00/00/0000 00:00:00', { placeholder: "00/00/0000 00:00:00" });
    $('.cep').mask('00000-000', { placeholder: "00000-000" });
    $('.smartphone_com_ddd').mask('(00) 00000-0000', { placeholder: "(00) 00000-0000" });
    $('.smartphone').mask('00000-0000', { placeholder: "00000-0000" });
    $('.telefone_com_ddd').mask('(00) 0000-0000', { placeholder: "(00) 0000-0000" });
    $('.ddd').mask('(00)', { placeholder: "(00)" });
    $('.mixed').mask('AAA 000-S0S');
    $('.ip_address').mask('099.099.099.099');
    $('.percent').mask('##0,00%', { reverse: true });
    $('.clear-if-not-match').mask("00/00/0000", { clearIfNotMatch: true });
    $('.placeholder').mask("00/00/0000", { placeholder: "__/__/____" });
    $('.fallback').mask("00r00r0000", {
        translation: {
            'r': {
                pattern: /[\/]/,
                fallback: '/'
            },
            placeholder: "__/__/____"
        }
    });

    $('.selectonfocus').mask("00/00/0000", { selectOnFocus: true });

    $('.cep_with_callback').mask('00000-000', {
        onComplete: function (cep)
        {
            console.log('Mask is done!:', cep);
        },
        onKeyPress: function (cep, event, currentField, options)
        {
            console.log('An key was pressed!:', cep, ' event: ', event, 'currentField: ', currentField.attr('class'), ' options: ', options);
        },
        onInvalid: function (val, e, field, invalid, options)
        {
            var error = invalid[0];
            console.log("Digit: ", error.v, " is invalid for the position: ", error.p, ". We expect something like: ", error.e);
        }
    });

    $('.crazy_cep').mask('00000-000', {
        onKeyPress: function (cep, e, field, options)
        {
            var masks = ['00000-000', '0-00-00-00'];
            mask = (cep.length > 7) ? masks[1] : masks[0];
            $('.crazy_cep').mask(mask, options);
        }
    });

    carregarMaskCNPJ();
    carregarMaskCPF();

    $('.money').mask('###.###.##0,00', { reverse: true });

    var SPMaskBehavior = function (val)
    {
        return val.replace(/\D/g, '').length === 11 ? '(00) 00000-0000' : '(00) 0000-00009';
    },
        spOptions = {
            onKeyPress: function (val, e, field, options)
            {
                field.mask(SPMaskBehavior.apply({}, arguments), options);
            }
        };

    $('.sp_celphones').mask(SPMaskBehavior, spOptions);

    $(".bt-mask-it").click(function ()
    {
        $(".mask-on-div").mask("000.000.000-00");
        $(".mask-on-div").fadeOut(500).fadeIn(500);
    });

    $('pre').each(function (i, e) { hljs.highlightBlock(e); });
});

function carregarMaskCNPJ()
{
    $('.cnpj').mask('00.000.000/0000-00', { reverse: true, placeholder: "99.999.999/9999-99" });
}

function carregarMaskCPF()
{
    $('.cpf').mask('000.000.000-00', { reverse: true, placeholder: "999.999.999-99" });
}