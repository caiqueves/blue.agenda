<template>
  <div class="botao-personalizado">
    <button type="submit" class="botao" :class="estiloDoBotao">{{ btn_text }}</button>
  </div>
</template>

<script>

export default {
  name: "Buttom-base",
  props: {
    btn_text: String,
    estilo: {
      required: false,
      default: 'padrao',
      type: String
    }
  },
  computed: {
    estiloDoBotao: function () {
      let estiloDoBotao;
      if (this.estilo == 'padrao' || !this.estilo) {
        estiloDoBotao = 'botao-padrao';
      } else if (this.estilo == 'token') {
        estiloDoBotao = 'botao-token';
      }
      return estiloDoBotao;
    }
  }
}
</script>

<style>
.botao-personalizado {
  margin: 35px 0px;
  margin-bottom: 15px;
  display: flex;
  align-items: center;
  justify-content: center;
}
.botao {
  font-size: 14px;
  font-weight: bold;
  text-transform: uppercase;
  padding: 10px 45px;
  border-radius: 25px;
  box-shadow: 1px 5px 10px rgba(0, 0, 0, 0.34);
  border: none;
}

.botao:hover {
  color: #222;
  background: #737373;
}

.botao:hover {
  transition: .5s;
  box-shadow: 0px 0px 0px rgba(152, 148, 148, 0.78);
  background: rgba(229, 149, 28, 0.54);
  color: #ffffff;
}

.botao-padrao {
  background: #222222;
  color: white;

}
.botao-token {
  padding: 10px 35px;
  font-size: 12px;
  text-transform: capitalize;
  color: white;
  background: rgba(255, 0, 0, 0.96);
}

</style>