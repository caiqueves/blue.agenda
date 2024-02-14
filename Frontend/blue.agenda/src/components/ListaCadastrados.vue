<template>

  <MessegesDeAlerts class="mensagem" :txt_mensagem="msg" :class="estiloDaMensagem" v-show="msg"/>

  <TituloPagina :titulo="titulo"/>

  <div class="container-md d-flex flex-wrap justify-content-lg-start m-auto">
    <div
        class="card flex-wrap mb-3 mt-3 m-lg-3"
        style="max-width: 18rem;"
        v-for="dados in cadastros.contatos"
        :key="dados.idContato"
        @change="updatedcadastrado($event, dados.idContato)">
      <div class="card-header ">
        <h5 class="card-title text-capitalize">#{{ dados.idContato }}</h5>
      </div>
      <div class="card-body">
        <div class="card-text card-text d-flex flex-column">
          <label>Nome</label>
          <input type="text" :value="dados.nome">
        </div>
        <div class="card-text d-flex flex-column">
          <label for="telefone">Telefone</label>
          <input type="number" id="telefone" :value="dados.telefone">
        </div>
        <div class="card-text d-flex flex-column">
          <label for="Email">Email</label>
          <input type="email" id="Email" :value="dados.email">
        </div>
        <div class="div-botao">
          <ButtomBase
              @click.prevent="deleteUsuario(dados.idContato)"
              :btn_text="excluir"
          />
          <ButtomBase
              @click.prevent="updatedcadastrado()"
              :btn_text="atualizar"
          />
        </div>
      </div>

    </div>
  </div>
</template>

<script>
import TituloPagina from "@/components/shared/TituloPagina";
import ButtomBase from "@/components/shared/Buttom-base";
import MessegesDeAlerts from "@/components/MessegesDeAlerts";

export default {
  name: "ListaCadastrados",
  components: {TituloPagina, ButtomBase, MessegesDeAlerts},
  data() {
    return {
      titulo: "LISTA DE CONTATOS",
      msg: null,
      alerta: "",
      
      id: null,
      nome: null,
      telefone: null,
      email: null,
     
      // botão
      excluir: 'Excluir',
      atualizar:'Atualizar',

      // api
      cadastros: []
    }
  },
  methods: {
    async getUsuarios() {

      const req = await fetch('http://localhost:5036/api/Agenda/BuscarContatos', {
          method: "GET",
          headers: {
            "Content-Type": "application/json"
          }
        });
      const data = await req.json();

      this.cadastros = data;

      //console.log(this.cadastros)
    },

    async deleteUsuario(id) {

      const RemoverContatoRequest = {
        contatoId: id,
        tipoOperacao: "RemoverContato",
      }

      const dataJson = JSON.stringify(RemoverContatoRequest);
      const req = await fetch('http://localhost:5036/api/Agenda/RemoverContato', {
          method: "DELETE",
          headers: {
            "Content-Type": "application/json"
          },
          body: dataJson
        });

      const res = await req.json();

      // mensagem após excluir usuario
      this.estilo = 'sucesso'
      this.msg = `${res.mensagem}`

      setTimeout(() => this.msg = "", 3000)

      this.getUsuarios();

    },
    /*
    async updatedcadastrado(event,id) {
    
      console.log(event);
      const dados = event.target.value;
    

    const dataJson = JSON.stringify(dados);

    const req = await fetch(`https://localhost:44321/api/Agenda/AtualizarPatch/${id}`, {
        method: "PATCH",
        body: dataJson
      });

    const res = await req.json();

    // Mensagem
    this.msg = `#${res.mensagem}`
    setTimeout(()=> document.location.reload(true), 3000)
    setTimeout(() => this.msg = "", 3000)  
    } */
  },
  mounted() {
   this.getUsuarios();
  },
  computed: {
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

<style scoped>

.div-botao {
  display: flex;
  justify-content: center;
  flex-direction: column;
}

.card {
  box-shadow: 0px 0px 15px rgba(0, 0, 0, 0.11);
}

.botao-personalizado {
  margin: 5px;
}

.card-text label, .card-title label {
  font-weight: bold;
}

.card-text input {
  border: none;
  border-radius: 5px;
}

.card-text input:hover {
  transition: 0.3s;
  background: rgba(171, 169, 169, 0.15);
}

.card-text, .card-title {
  margin: 10px auto;
}

@media screen and (max-width: 551px) {
  .container-md {
    justify-content: center;
  }
}
</style>