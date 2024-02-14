<template>
  <MessegesDeAlerts :txt_mensagem="msg" :class="estiloDaMensagem" v-show="msg" :estilo="estilo" />
  <div class="container-md">
    <TituloPagina :titulo="titulo" />
    <form class="w-75 m-auto" @submit.prevent="criarContato($event)">
      <div class="form-group">
        <label for="nome">Nome completo</label>
        <input type="text" class="form-control" :style="campo_info" id="nome" v-model="nome"
          :placeholder="campo_obg_nome">
      </div>
      <div class="form-group">
        <label for="telefone">Telefone</label>
        <input type="tel" class="form-control" :style="campo_info" v-model="telefone" id="telefone"
          :placeholder="campo_obg_telefone">
      </div>
      <div class="form-group">
        <label for="email">Email</label>
        <input type="email" class="form-control" :style="campo_info" v-model="email" id="email"
        :placeholder="campo_obg_email">
      </div>
      <ButtomBase :btn_text="btn" />
    </form>
  </div>
</template>

<script>

import ButtomBase from "@/components/shared/Buttom-base";
import MessegesDeAlerts from "@/components/MessegesDeAlerts";
import TituloPagina from "@/components/shared/TituloPagina";

export default {
  name: "FormUsuario",
  components: {
    ButtomBase,
    MessegesDeAlerts,
    TituloPagina
  },
  data() {
    return {
      // configurações padrões dinâmica por pagina!
      btn: 'SALVAR',
      btnn:'AGENDA',
      titulo: 'ADICIONAR CONTATO',
      campo_info: null,
      campo_obg_nome: 'Digite seu nome completo',
      campo_obg_telefone: 'Digite um telefone',
      campo_obg_email: 'Digite um email',
      msg: null,
      estilo: null,

      nome: null,
      telefone: null,
      email: null,
      tipoOperacao: null
    }
  },
  methods: {

    async criarContato(e) {

      e.preventDefault();

      const adicionarContatoRequest = {
        nome: this.nome,
        telefone: this.telefone,
        email: this.email,
        tipoOperacao: "AdicionarContato"
      }

      const dataJson = JSON.stringify(adicionarContatoRequest);
      console.info(dataJson);

      // validação basica, para ver o comportamento das inserções de novos cadastros
      if (this.nome != null) {

        const req = await fetch('http://localhost:5036/api/Agenda/AdicionarContato', {
          method: "POST",
          headers: {
            "Content-Type": "application/json"
          },
          body: dataJson
        });

        const rest = await req.json();

        this.requisicao = rest;

        this.estilo = 'sucesso';
        this.campo_info = 'box-shadom: 0px 0px 5px green;'
        this.msg = `Cadastro realizado com sucesso!`

        setTimeout(() => this.msg = "", 3000)
        setTimeout(() => this.campo_info = "box-shadom: initial", 2000)

      } else if (this.nome == null) {

        this.estilo = 'erro';
        this.campo_info = 'box-shadow: 0px 0px 5px red'
        this.msg = `Erro ao cadastrar usuário!`
        this.campo_obg_nome = 'inválido campo precisa ter no minimo 3 caracter!'

        setTimeout(() => this.msg = "", 3000)
        setTimeout(() => this.campo_info = "box-shadom: initial", 2000)
        setTimeout(() => this.campo_obg_nome = 'Digite seu primeiro nome', 2500)
      }

      // zerando o formulario após a inserção
      this.nome = "";
      this.telefone = "";
      this.email = "";
      
      //this.$router.push('/Agenda');
    },

    async getUsuarios() {

      const req = await fetch('http://localhost:5036/api/Agenda/BuscarContatos');

      const data = await req.json();

      this.cadastros = data;

    },
  },
  computed: {
    //função de desição tipo de mensagem que vai ser retornada
    estiloDaMensagem: function () {
      let estiloDaMensagem;
      if (this.estilo == 'sucesso' || !this.estilo) {
        estiloDaMensagem = 'alert-success';
      } else if (this.estilo == 'erro') {
        estiloDaMensagem = 'alert-danger';
      }
      return estiloDaMensagem;
    }
  }
}
</script>
