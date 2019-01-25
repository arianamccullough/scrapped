<template>
  <div id="app">
    <navi></navi>
    <router-view />
  </div>
</template>

<script>
  import navi from '@/components/Navi.vue'
  export default {
    name: 'app',
    data() {
      return {
      }
    },
    mounted() {
      this.$store.dispatch("authenticate")
    },
    components: {
      navi
    },
  }

</script>

<style>
  #app {
    font-family: 'Special Elite', cursive;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #2c3e50;
  }
</style>