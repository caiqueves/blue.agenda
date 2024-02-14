<template>
  <div>
    <div class="alert sucesso text-center" :class="estilo" role="alert" >
      {{ txt_mensagem }}
    </div>
  </div>
</template>

<script>
export default {
  name: "MessegesDeAlerts",
  props: {
    txt_mensagem:String,
    estilo: {
      required: false,
      default: 'sucesso',
      type: String
    }
  }
}
</script>