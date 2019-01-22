<template>
  <div class="onekeep">

    <keep :keep="keep"></keep>

  </div>
</template>

<script>
  import keep from '@/components/Keep.vue'

  export default {
    name: 'onekeep',
    mounted() {
      // this.$store.dispatch("authenticate")
      if (!this.keeps.length) {
        this.$store.dispatch("getKeep", this.$route.params.keepId)
      }

    },
    data() {
      return {
      }
    },

    components: {
      keep
    },
    computed: {
      keep() {
        return this.$store.state.keep
      },
      keeps() {
        return this.$store.state.keeps
      }
    },
    methods: {

    }
  }

</script>

<style>


</style>