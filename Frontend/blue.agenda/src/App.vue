<template>
  <nav class="navbar navbar-expand-lg navbar-light navbar-dark bg-dark">
    <div class="container-md ">
      <a class="navbar-brand" href="#">
        <img src="./assets/logo.png" width="30" height="30" class="d-inline-block align-top" alt="">
        Agenda Blue
      </a>
      <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNavAltMarkup"
              aria-controls="navbarNavAltMarkup" aria-expanded="false" aria-label="Alterna navegação">
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse justify-content-end" id="navbarNavAltMarkup">
        <div class="navbar-nav ">
          <router-link class="nav-link" to="/">Adicionar Contato</router-link>
          <router-link class="nav-link" to="/Agenda">Agenda</router-link>
        </div>
      </div>
    </div>
  </nav>
  <router-view/>
</template>

<style>

</style>
