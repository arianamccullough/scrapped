<template>
  <div class="keep container-fluid">
    <div class="row justify-content-center">
      <div class="card col-6 mt-5">
        <h1>{{keep.name}}</h1>
        <img :src="keep.img">
        <h6><i>{{keep.description}}</i></h6>
        <h6><b>Views</b>: {{keep.views+1}}
          <b>Saves</b>:{{keep.saves}}</h6>
      </div>
    </div>
  </div>
  </div>

</template>

<script>
  export default {
    name: 'keep',
    mounted() {
      let keep = this.$store.state.allKeeps.find(k => k.id == this.$route.params.keepId)
      if (keep) {
        keep.views++
        this.$store.dispatch("updateKeep", keep)
      }
    },
    created() {
      return this.$store.dispatch("getKeep", this.$route.params.keepId)
      return this.$store.dispatch("getVaults")
    },
    data() {
      return {
      }
    },
    computed: {
      keep() {
        return this.$store.state.keep
      },
      user() {
        return this.$store.state.user
      }
    },
    methods: {
    },
    components: {
    }
  }
</script>

<style scoped>
  img {
    width: 100%;
    height: 400px;
  }

  .card-font {
    color: black;
  }

  .card {
    outline: 1px solid black;
  }

  .card:hover {
    outline: 1px solid black;
    box-shadow: 3px 3px rgb(185, 185, 185);
  }
</style>