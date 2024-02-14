<template>
  <div>
    <h1 class="m-5 text-center">{{ titulo }}</h1>
  </div>
</template>

<script>
export default {
  name: "TituloPagina",
  props: {
    titulo:String
  }
}
</script>
