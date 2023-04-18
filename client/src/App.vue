<template lang="pug">
#app
  Navbar#nav
  #request-loading(v-if="loading") Loading
  router-view
</template>

<script lang="ts">
import Vue from 'vue';
import Navbar from './components/Navbar.vue';
import { store } from './store';

export default Vue.extend({
  components: {
    Navbar
  },
  computed: {
    loading() {
      return store.loading > 0;
    }
  }
})
</script>

<style lang="scss">

@import "./style/core.scss";

#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

$navbar-height: 2.5em;

#nav {
  position: fixed;
  width: 100%;
  top: 0;
  height: $navbar-height;
  max-height: $navbar-height;
  box-sizing: border-box;
}

html, body {
  margin: 0;
  padding: 0;
  min-height: 100vh;
}

body {
  padding-top: calc($navbar-height + 2em);
}

#request-loading {
  z-index: 9999;
  position: fixed;
  width: 100%;
  height: 100%;
  top: 0;
  background-color: rgba($dark, 0.5);
  color: $ultradark;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  font-size: 40px;
}

</style>
