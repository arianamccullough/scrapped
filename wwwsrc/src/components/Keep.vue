<template>
  <div class="keep card m-2">
    <h4><b>{{keep.name}} </b></h4>
    <!-- <p><i>{{keep.description}}</i></p> -->
    <img :src="keep.img">
    <div class="row">
      <div class="col-6">Views: {{keep.views}}</div>
      <div class="col-6">Saves: {{keep.saves}}</div>
    </div>
    <div class="row">
      <div class="col-6">
        <!-- <router-link :to="{name: 'onekeep'}"> -->
        <button @click="makeTargetKeep()">
          View Keep
        </button>
        <button @click="deleteKeep()">Delete Keep</button>
        <!-- </router-link> -->
      </div>
      <div class="col-6">
        <div class="dropdown">
          <button class="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown"
            aria-haspopup="true" aria-expanded="false">
            Save Keep To... </button>
          <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
          </div>
        </div>
      </div>
    </div>
  </div>

  </div>
</template>

<script>
  export default {
    name: 'keep',
    data() {
      return {

      }
    },

    computed: {

    },


    props: ['keep'],

    methods: {
      makeTargetKeep() {
        this.$router.push({ name: "onekeep", params: { keepId: this.keep.id } })
        this.$store.dispatch("makeTargetKeep", this.keep)
        keep.views++
      },
      deleteKeep() {
        this.$store.dispatch('deleteKeep', this.keep.id)
      },


    }
  }
</script>

<style scoped>
  .card {
    width: 400px;
  }

  img {
    width: 100%;
    height: 40vh;
  }
</style>